    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Net.Sockets;
    using System.ComponentModel;
    using System.Threading;
    using System.Net;
    
    namespace ConsoleApplication13
    {
        class Program
        {
            static void Main()
            {
                var worker = new BackgroundWorker();
                worker.WorkerReportsProgress = true;
                worker.WorkerSupportsCancellation = true;
    
                worker.ProgressChanged += (s, args) =>
                {
                    Console.WriteLine(args.UserState);
                };
    
                worker.DoWork += (s, args) =>
                {
                    // startup the server on localhost 
                    var ipAddress = IPAddress.Parse("127.0.0.1");
                    TcpListener server = new TcpListener(ipAddress, 2104);
                    server.Start();
    
                    while (!worker.CancellationPending)
                    {
                        Console.WriteLine("The server is waiting on {0}:2104...", ipAddress.ToString());
    
                        // as long as we're not pending a cancellation, let's keep accepting requests 
                        TcpClient attachedClient = server.AcceptTcpClient();
    
                        StreamReader clientIn = new StreamReader(attachedClient.GetStream());
                        StreamWriter clientOut = new StreamWriter(attachedClient.GetStream());
                        clientOut.AutoFlush = true;
    
                        string msg;
                        while ((msg = clientIn.ReadLine()) != null)
                        {
                            Console.WriteLine("The server received: {0}", msg);
                            clientOut.WriteLine(string.Format("The server replied with: {0}", msg));
                        }
                    }
                };
    
                worker.RunWorkerAsync();
    
                Console.WriteLine("Attempting to establish a connection to the server...");
    
                TcpClient client = new TcpClient();
    
                for (int i = 0; i < 3; i++)
                {
                    var result = client.BeginConnect("localhost", 2104, null, null);
    
                    // give the client 5 seconds to connect
                    result.AsyncWaitHandle.WaitOne(5000);
    
                    if (!client.Connected)
                    {
                        try { client.EndConnect(result); }
                        catch (SocketException) { }
    
                        string message = "There was an error connecting to the server ... {0}";
    
                        if (i == 2) { Console.WriteLine(message, "aborting"); }
                        else { Console.WriteLine(message, "retrying"); }
    
                        continue;
                    }
    
                    break;
                }
    
                if (client.Connected)
                {
                    Console.WriteLine("The client is connected to the server...");
    
                    StreamReader clientIn = new StreamReader(client.GetStream());
                    StreamWriter clientOut = new StreamWriter(client.GetStream());
    
                    clientOut.AutoFlush = true;
    
                    string key;
                    while ((key = Console.ReadLine()) != string.Empty)
                    {
                        clientOut.WriteLine(key);
                        Console.WriteLine(clientIn.ReadLine());
                    }
                }
                else { Console.ReadKey(); }
            }
        }
    }
