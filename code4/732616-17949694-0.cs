    using System;
    using System.Collections.Generic;
    using System.Text;
    
    namespace AeProxy
    {
        using System.IO;
        using System.Net;
        using System.Net.Sockets;
        using System.Threading;
        // Need to install Wintellect.Threading via NuGet for this:
        using Wintellect.Threading.AsyncProgModel;
    
        class Program
        {
            static void Main(string[] args)
            {
                var ae = new AsyncEnumerator() {SyncContext = null};
                var mainOp = ae.BeginExecute(ListenerFiber(ae), null, null);
                // block until main server is finished
                ae.EndExecute(mainOp);
            }
    
            static IEnumerator<int> ListenerFiber(AsyncEnumerator ae)
            {
                var listeningServer = new TcpListener(IPAddress.Loopback, 9998);
                listeningServer.Start();
                while (!ae.IsCanceled())
                {
                    listeningServer.BeginAcceptTcpClient(ae.End(0, listeningServer.EndAcceptTcpClient), null);
                    yield return 1;
                    if (ae.IsCanceled()) yield break;
                    var clientSocket = listeningServer.EndAcceptTcpClient(ae.DequeueAsyncResult());
                    var clientAe = new AsyncEnumerator() { SyncContext = null };
                    clientAe.BeginExecute(
                        ClientFiber(clientAe, clientSocket),
                        ar =>
                            {
                                try
                                {
                                    clientAe.EndExecute(ar);
                                }
                                catch { }
                        }, null);
                }
            }
    
            static long clients = 0;
    
            static IEnumerator<int> ClientFiber(AsyncEnumerator ae, TcpClient clientSocket)
            {
                Console.WriteLine("ClientFibers ++{0}", Interlocked.Increment(ref clients));
                try
                {
                    // original code to do handshaking and connect to remote host
                    var ns1 = clientSocket.GetStream();
                    var r1 = new BinaryReader(ns1);
                    var w1 = new BinaryWriter(ns1);
    
                    if (!(r1.ReadByte() == 5 && r1.ReadByte() == 1)) yield break;
                    var c = r1.ReadByte();
                    for (int i = 0; i < c; ++i) r1.ReadByte();
                    w1.Write((byte)5);
                    w1.Write((byte)0);
    
                    if (!(r1.ReadByte() == 5 && r1.ReadByte() == 1)) yield break;
                    if (r1.ReadByte() != 0) yield break;
    
                    byte[] ipAddr = null;
                    string hostname = null;
                    var type = r1.ReadByte();
                    switch (type)
                    {
                        case 1:
                            ipAddr = r1.ReadBytes(4);
                            break;
                        case 3:
                            hostname = Encoding.ASCII.GetString(r1.ReadBytes(r1.ReadByte()));
                            break;
                        case 4:
                            throw new Exception();
                    }
                    var nhport = r1.ReadInt16();
                    var port = IPAddress.NetworkToHostOrder(nhport);
                    var socketout = new TcpClient();
                    if (hostname != null) socketout.Connect(hostname, port);
                    else socketout.Connect(new IPAddress(ipAddr), port);
                    w1.Write((byte)5);
                    w1.Write((byte)0);
                    w1.Write((byte)0);
                    w1.Write(type);
                    switch (type)
                    {
                        case 1:
                            w1.Write(ipAddr);
                            break;
                        case 2:
                            w1.Write((byte)hostname.Length);
                            w1.Write(Encoding.ASCII.GetBytes(hostname), 0, hostname.Length);
                            break;
                    }
                    w1.Write(nhport);
                    using (var ns2 = socketout.GetStream())
                    {
                        var forwardAe = new AsyncEnumerator() { SyncContext = null };
                        forwardAe.BeginExecute(
                            ForwardingFiber(forwardAe, ns1, ns2), ae.EndVoid(0, forwardAe.EndExecute), null);
                        yield return 1;
                        if (ae.IsCanceled()) yield break;
                        forwardAe.EndExecute(ae.DequeueAsyncResult());
                    }
                }
                finally
                {
                    Console.WriteLine("ClientFibers --{0}", Interlocked.Decrement(ref clients));
                }
            }
    
            private enum Operation { OutboundWrite, OutboundRead, InboundRead, InboundWrite } 
    
            const int bufsize = 4096;
    
            static IEnumerator<int> ForwardingFiber(AsyncEnumerator ae, NetworkStream inputStream, NetworkStream outputStream)
            {
                while (!ae.IsCanceled())
                {
                    byte[] outputRead = new byte[bufsize], outputWrite = new byte[bufsize];
                    byte[] inputRead = new byte[bufsize], inputWrite = new byte[bufsize];
                    // start off output and input reads.
                    // NB ObjectDisposedExceptions can be raised here when a socket is closed while an async read is in progress.
                    outputStream.BeginRead(outputRead, 0, bufsize, ae.End(1, ar => outputStream.EndRead(ar)), Operation.OutboundRead);
                    inputStream.BeginRead(inputRead, 0, bufsize, ae.End(1, ar => inputStream.EndRead(ar)), Operation.InboundRead);
                    var pendingops = 2;
                    while (!ae.IsCanceled())
                    {
                        // wait for the next operation to complete, the state object passed to each async
                        // call can be used to find out what completed.
                        if (pendingops == 0) yield break;
                        yield return 1;
                        if (!ae.IsCanceled())
                        {
                            int byteCount;
                            var latestEvent = ae.DequeueAsyncResult();
                            var currentOp = (Operation)latestEvent.AsyncState;
                            if (currentOp == Operation.InboundRead)
                            {
                                byteCount = inputStream.EndRead(latestEvent);
                                if (byteCount == 0)
                                {
                                    pendingops--;
                                    outputStream.Close();
                                    continue;
                                }
                                Array.Copy(inputRead, outputWrite, byteCount);
                                outputStream.BeginWrite(outputWrite, 0, byteCount, ae.EndVoid(1, outputStream.EndWrite), Operation.OutboundWrite);
                                inputStream.BeginRead(inputRead, 0, bufsize, ae.End(1, ar => inputStream.EndRead(ar)), Operation.InboundRead);
                            }
                            else if (currentOp == Operation.OutboundRead)
                            {
                                byteCount = outputStream.EndRead(latestEvent);
                                if (byteCount == 0)
                                {
                                    pendingops--;
                                    inputStream.Close();
                                    continue;
                                }
                                Array.Copy(outputRead, inputWrite, byteCount);
                                inputStream.BeginWrite(inputWrite, 0, byteCount, ae.EndVoid(1, inputStream.EndWrite), Operation.InboundWrite);
                                outputStream.BeginRead(outputRead, 0, bufsize, ae.End(1, ar => outputStream.EndRead(ar)), Operation.OutboundRead);
                            }
                            else if (currentOp == Operation.InboundWrite)
                            {
                                inputStream.EndWrite(latestEvent);
                            }
                            else if (currentOp == Operation.OutboundWrite)
                            {
                                outputStream.EndWrite(latestEvent);
                            }
                        }
                    }
                }
            }
        }
    }
