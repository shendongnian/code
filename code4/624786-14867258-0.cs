    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Net;
    using System.Net.Sockets;
    using System.IO;
    using System.ComponentModel;
    namespace PortalClient
    {
        class Program
        {
            static int partloop;
            static bool bool1;
            static byte[] data05;
            static int int03;
            static int int04;
            static int int05;
            static int numbytesreceived;
            static BackgroundWorker bw1;
            static int bytestoreceive;
            static string s1;
            static byte[] data03;
            static int int02;
            static string str01;
            static int length;
            static IPEndPoint ipe01;
            static TcpClient tcp01;
            static FileStream s01;
            static string ip01;
            static string port01;
            static string path01;
            static byte[] data01;
            static byte[] data02;
            static byte[] data04;
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
                        Console.Title = (" Portal Client " + version);
                        ConsoleColor ccolor1 = new ConsoleColor();
                        ccolor1 = Console.ForegroundColor;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine();
                        Console.WriteLine(@"
     __________              __         .__    _________ .__  .__               __   
     \______   \____________/  |______  |  |   \_   ___ \|  | |__| ____   _____/  |_ 
      |     ___/  _ \_  __ \   __\__  \ |  |   /    \  \/|  | |  |/ __ \ /    \   __\
      |    |  (  <_> )  | \/|  |  / __ \|  |__ \     \___|  |_|  \  ___/|   |  \  |  
      |____|   \____/|__|   |__| (____  /____/  \______  /____/__|\___  >___|  /__|  
                                      \/               \/             \/     \/       " + version);
                        Console.WriteLine();
                        Console.ForegroundColor = ccolor1;
                        data01 = new byte[20];
                        data03 = new byte[100];
                        data04 = new byte[100];
                        Console.Write(" Enter IPv4 address of server : ");
                        ip01 = Console.ReadLine();
                        Console.Write(" Enter port to connect on : ");
                        port01 = Console.ReadLine();
                        ipe01 = new IPEndPoint(IPAddress.Parse(ip01), Convert.ToInt32(port01));
                        tcp01 = new TcpClient();
                        Console.WriteLine(" Connecting...");
                        tcp01.Connect(ipe01);
                        Console.WriteLine(" Done.");
                        tcp01.Client.Receive(data04, SocketFlags.None);
                        System.Threading.Thread.Sleep(100);
                        Console.WriteLine(" Server message : " + Encoding.UTF8.GetString(data04));
                        tcp01.Client.Receive(data03, SocketFlags.None);
                        System.Threading.Thread.Sleep(100);
                        Console.WriteLine(" File on server : " + Encoding.UTF8.GetString(data03));
                        tcp01.Client.Receive(data01, SocketFlags.None);
                        System.Threading.Thread.Sleep(100);
                        str01 = Encoding.UTF8.GetString(data01);
                        Console.WriteLine();
                        Console.WriteLine(" file size : " + str01);
                        Console.WriteLine();
                        Console.Write(" Enter the number you see above : ");
                        length = Convert.ToInt32(Console.ReadLine());
                        bytestoreceive = length;
                        Console.Write(" Save file as : ");
                        path01 = Console.ReadLine();
                        for (int i = 1; i <= 60000; i++)
                        {
                            if (length % i == 0) { int02 = i; }
                        }
                        if (length < 60000) { int02 = length; }
                        int03 = length / int02;
                        s01 = File.OpenWrite(@path01);
                        Console.WriteLine(" Receiving file from " + tcp01.Client.RemoteEndPoint.ToString() + "...");
                        tcp01.Client.Send(new byte[1], SocketFlags.None);
                        System.Threading.Thread.Sleep(1000);
                        while (bytestoreceive > 0)
                        {
                            bw1 = new BackgroundWorker();
                            bw1.DoWork += new DoWorkEventHandler(bw1_DoWork);
                            bw1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw1_RunWorkerCompleted);
                            bool1 = false;
                            numbytesreceived = 0;
                            data02 = new byte[int02];
                            bw1.RunWorkerAsync();
                            while (numbytesreceived == 0) { }
                            while (numbytesreceived < int02)
                            {
                                bw1 = new BackgroundWorker();
                                bw1.DoWork += new DoWorkEventHandler(bw1_DoWork);
                                bw1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw1_RunWorkerCompleted);
                                bool1 = true;
                                partloop += 1;
                                int04 = int02 - numbytesreceived;
                                tcp01.Client.Send(Encoding.UTF8.GetBytes("2"), 0, 1, SocketFlags.None);
                                int05 = 0;
                                data05 = new byte[int04];
                                if (int04 >= 1 && int04 <= 9) { s1 = int04 + "xxxx"; }
                                if (int04 >= 10 && int04 <= 99) { s1 = int04 + "xxx"; }
                                if (int04 >= 100 && int04 <= 999) { s1 = int04 + "xx"; }
                                if (int04 >= 1000 && int04 <= 9999) { s1 = int04 + "x"; }
                                if (int04 > 10000 && int04 <= 60000) { s1 = int04.ToString(); }
                                tcp01.Client.Send(Encoding.UTF8.GetBytes(s1), 0, 5, SocketFlags.None);
                                bw1.RunWorkerAsync();
                                while (int05 == 0) { }
                                if (int05 == 0) { throw new Exception("ex1"); }
                                numbytesreceived += int05;
                                bytestoreceive -= numbytesreceived;
                                s01.Write(data05, 0, data05.Length);
                                Console.WriteLine(" Received " + (length - bytestoreceive) + " / " + length + " bytes | P.B.R. loops: " + partloop.ToString());
                                Console.SetCursorPosition(0, Console.CursorTop - 1);
                            }
    
                            if (bool1 == false)
                            {
    
                                bytestoreceive -= numbytesreceived;
                                s01.Write(data02, 0, int02);
                                tcp01.Client.Send(new byte[1], 0, 1, SocketFlags.None);
                                Console.WriteLine(" Received " + (length - bytestoreceive) + " / " + length + " bytes | P.B.R. loops: " + partloop.ToString());
                                Console.SetCursorPosition(0, Console.CursorTop - 1);
                            }
                        }
                        Console.SetCursorPosition(0, Console.CursorTop + 1);
                        Console.WriteLine();
                        System.Threading.Thread.Sleep(500);
                        s01.Close();
                        Console.WriteLine(" Received all data.");
                        Console.WriteLine(" Press enter to disconnect...");
                        Console.ReadLine();
                        tcp01.Client.Send(new byte[1], SocketFlags.None);
                        System.Threading.Thread.Sleep(1000);
                        Console.WriteLine(" Disconnecting...");
                        tcp01.Close();
                        Console.WriteLine(" Done.");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(" Error! : " + e.Message.ToString() + " - " + e.Data.ToString() + " - " + e.TargetSite.ToString());
                        if (!(tcp01 == null)) { tcp01.Close(); }
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
                    if (!(tcp01 == null)) { tcp01.Close(); }
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
                        numbytesreceived = tcp01.Client.Receive(data02, 0, int02, SocketFlags.None);
                    }
                    if (bool1 == true)
                    {
                        int05 = tcp01.Client.Receive(data05, 0, int04, SocketFlags.None);
                    }
                }
                catch (Exception e2)
                {
                    Console.WriteLine(" Error! : " + e2.Message.ToString() + " - " + e2.Data.ToString() + " - " + e2.TargetSite.ToString());
                    if (!(tcp01 == null)) { tcp01.Close(); }
                    if (!(s01 == null)) { s01.Close(); }
                    Console.Write(" Press enter to continue..."); Console.ReadLine();
                    newvoid();
                }
            }
        }
    }
