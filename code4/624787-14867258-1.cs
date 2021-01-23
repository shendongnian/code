    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Net;
    using System.Net.Sockets;
    using System.IO;
    using System.ComponentModel;
    namespace PortalServer
    {
        class Program
        {
            static int bytesresent;
            static BackgroundWorker bw1;
            static int int06;
            static int int05;
            static string string01;
            static int bytesCreceived;
            static byte[] data06;
            static byte[] data07;
            static byte[] data08;
            static int bytessent;
            static bool bool1;
            static int bytestosend;
            static long length;
            static int int03;
            static int int02;
            static TcpListener tcp01;
            static TcpClient tcp02;
            static FileStream s01;
            static byte[] data01;
            static byte[] data03;
            static byte[] data04;
            static byte[] data05;
            static string str01;
            static string str02;
            static IPEndPoint ipe01;
            static string port01;
            static void Main(string[] args)
            {
                newvoid();
            }
            static void newvoid()
            {
                while (true)
                {
                    try
                    {
                        Console.Clear();
                        Console.WindowWidth = 95;
                        string version = "V:1.1.4";
                        Console.Title = (" Portal Server " + version);
                        ConsoleColor ccolor1 = new ConsoleColor();
                        ccolor1 = Console.ForegroundColor;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine();
                        Console.WriteLine(@"
     __________              __         .__      _________                                
     \______   \____________/  |______  |  |    /   _____/ ______________  __ ___________ 
      |     ___/  _ \_  __ \   __\__  \ |  |    \_____  \_/ __ \_  __ \  \/ // __ \_  __ \
      |    |  (  <_> )  | \/|  |  / __ \|  |__  /        \  ___/|  | \/\   /\  ___/|  | \/
      |____|   \____/|__|   |__| (____  /____/ /_______  /\___  >__|    \_/  \___  >__|   
                                      \/               \/     \/                 \/       " + version);
                        Console.WriteLine();
                        Console.ForegroundColor = ccolor1;
                        Console.Write(" Enter port for connecting clients : ");
                        port01 = Console.ReadLine();
                        Console.Write(" Enter path of file to send : ");
                        str01 = Console.ReadLine();
                        ipe01 = new IPEndPoint(IPAddress.Any, Convert.ToInt32(port01));
                        tcp01 = new TcpListener(ipe01);
                        Console.Write(" Enter server message : ");
                        str02 = Console.ReadLine();
                        s01 = File.OpenRead(@str01);
                        length = s01.Length;
                        bytestosend = (int)length;
                        for (int i = 1; i <= 60000; i++)
                        {
                            if (length % i == 0) { int02 = i; }
                        }
                        if (length < 60000) { int02 = (int)length; }
    
                        int03 = (int)length / int02;
                        tcp01.Start();
                        Console.WriteLine(" Server started. Waiting for clients...");
                        tcp02 = tcp01.AcceptTcpClient();
                        Console.WriteLine(" Client " + tcp02.Client.RemoteEndPoint.ToString() + " connected.");
                        data05 = Encoding.UTF8.GetBytes(str02);
                        tcp02.Client.Send(data05, SocketFlags.None);
                        System.Threading.Thread.Sleep(500);
                        data04 = Encoding.UTF8.GetBytes(str01);
                        tcp02.Client.Send(data04, SocketFlags.None);
                        System.Threading.Thread.Sleep(500);
                        data03 = Encoding.UTF8.GetBytes(length.ToString());
                        tcp02.Client.Send(data03, SocketFlags.None);
                        System.Threading.Thread.Sleep(500);
                        Console.WriteLine(" Waiting for response...");
                        tcp02.Client.Receive(new byte[1], SocketFlags.None);
                        Console.WriteLine(" Received response...");
                        Console.WriteLine(" Sending file to " + tcp02.Client.RemoteEndPoint.ToString() + "...");
                        System.Threading.Thread.Sleep(1);
                        while (bytestosend > 0)
                        {
                            System.Threading.Thread.Sleep(50);
                            bool1 = false;
                            bytessent = 0;
                            bw1 = new BackgroundWorker();
                            bw1.DoWork += new DoWorkEventHandler(bw1_DoWork);
                            bw1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw1_RunWorkerCompleted);
                            data01 = new byte[int02];
                            s01.Read(data01, 0, data01.Length);
                            bw1.RunWorkerAsync();
                            while (bytessent == 0) { }
                            if (bytessent != int02) { throw new Exception("unable to write bytes, insufficient memory."); }
                            while (true)
                            {
                                data07 = new byte[1];
                                tcp02.Client.Receive(data07, 0, 1, SocketFlags.None);
                                if (Encoding.UTF8.GetString(data07) == "2")
                                {
                                    bytesresent = 0;
                                    bool1 = true;
                                    bw1 = new BackgroundWorker();
                                    bw1.DoWork += new DoWorkEventHandler(bw1_DoWork);
                                    bw1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw1_RunWorkerCompleted);
                                    data06 = new byte[5];
                                    bytesCreceived = tcp02.Client.Receive(data06, 0, 5, SocketFlags.None);
                                    if (bytesCreceived != 5) { throw new Exception("invalid client response."); }
                                    string01 = Encoding.UTF8.GetString(data06);
                                    string01 = string01.Replace("x", "");
                                    int05 = Convert.ToInt32(string01);
                                    int06 = int02 - int05;
                                    bytestosend -= int05;
                                    data08 = new byte[int05];
                                    Buffer.BlockCopy(data01, int06, data08, 0, int05);
                                    bw1.RunWorkerAsync();
                                    while (bytesresent == 0) { }
                                    Console.WriteLine(" Sent " + (length - bytestosend) + " / " + length + " bytes");
                                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                                    System.Threading.Thread.Sleep(50);
                                }
                                if (Encoding.UTF8.GetString(data07) != "2")
                                {
                                    bool1 = false;
                                    bytestosend -= bytessent;
                                    Console.WriteLine(" Sent " + (length - bytestosend) + " / " + length + " bytes");
                                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                                    break;
                                }
                            }
                        }
                        Console.SetCursorPosition(0, Console.CursorTop + 1);
                        Console.WriteLine();
                        System.Threading.Thread.Sleep(500);
                        s01.Close();
                        Console.WriteLine(" All data sent.");
                        Console.WriteLine(" Waiting for terminate message...");
                        tcp02.Client.Receive(new byte[1], SocketFlags.None);
                        Console.WriteLine(" Received terminate message.");
                        tcp02.Close();
                        Console.WriteLine(" Stopping client and server.");
                        tcp01.Stop();
                        Console.WriteLine(" Done. Press enter to continue...");
                        Console.ReadLine();
                    }
    
                    catch (Exception e)
                    {
                        Console.WriteLine(" Error! : " + e.Message.ToString() + " - " + e.Data.ToString() + " - " + e.TargetSite.ToString());
                        if (!(tcp02 == null)) { tcp02.Close(); }
                        if (!(tcp01 == null)) { tcp01.Stop(); }
                        if (!(s01 == null)) { s01.Close(); }
                        Console.Write(" Press enter to continue..."); Console.ReadLine();
                        newvoid();
                    }
                }
            }
    
            static void bw1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
            {
                try
                {
                    bw1.Dispose();
                }
                catch (Exception e1)
                {
                    Console.WriteLine(" Error! : " + e1.Message.ToString() + " - " + e1.Data.ToString() + " - " + e1.TargetSite.ToString());
                    if (!(tcp02 == null)) { tcp02.Close(); }
                    if (!(tcp01 == null)) { tcp01.Stop(); }
                    if (!(s01 == null)) { s01.Close(); }
                    Console.Write(" Press enter to continue..."); Console.ReadLine();
                    newvoid();
                }
            }
    
            static void bw1_DoWork(object sender, DoWorkEventArgs e)
            {
                try
                {
                    if (bool1 == false)
                    {
                        bytessent = tcp02.Client.Send(data01, 0, data01.Length, SocketFlags.None);
                    }
                    if (bool1 == true)
                    {
                        bytesresent = tcp02.Client.Send(data08, 0, data08.Length, SocketFlags.None);
                    }
                }
                catch(Exception e2)
                {
                    Console.WriteLine(" Error! : " + e2.Message.ToString() + " - " + e2.Data.ToString() + " - " + e2.TargetSite.ToString());
                    if (!(tcp02 == null)) { tcp02.Close(); }
                    if (!(tcp01 == null)) { tcp01.Stop(); }
                    Console.Write(" Press enter to continue..."); Console.ReadLine();
                    if (!(s01 == null)) { s01.Close(); }
                    newvoid();
                }
            }
        }
    }
     
