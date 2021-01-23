    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.Net;
    using System.Net.Sockets;
    using System.Threading;
    namespace SERVER_WIN
    {
        public partial class Form1 : Form
        {
            //Declare and Initialize the IP Adress
            static IPAddress ipAd = IPAddress.Parse("10.1.42.31");
            //Declare and Initilize the Port Number;
            static int PortNumber = 8888;
            /* Initializes the Listener */
            TcpListener ServerListener = new TcpListener(ipAd, PortNumber);
            TcpClient clientSocket = default(TcpClient);
            public Form1()
            {
                InitializeComponent();
            }
            private void Form1_Load(object sender, EventArgs e)
            {
                Thread ThreadingServer = new Thread(StartServer);
                ThreadingServer.Start();
            }
            private void THREAD_MOD(string teste)
            {
                txtStatus.Text += Environment.NewLine + teste;
            }
            private void StartServer()
            {
                Action<string> DelegateTeste_ModifyText = THREAD_MOD;            
                ServerListener.Start();
                Invoke(DelegateTeste_ModifyText, "Server waiting connections!");
                clientSocket = ServerListener.AcceptTcpClient();
                Invoke(DelegateTeste_ModifyText, "Server ready!");
                while (true)
                {
                    try
                    {
                        NetworkStream networkStream = clientSocket.GetStream();
                        byte[] bytesFrom = new byte[20];
                        networkStream.Read(bytesFrom, 0, 20);
                        string dataFromClient = System.Text.Encoding.ASCII.GetString(bytesFrom);
                        dataFromClient = dataFromClient.Substring(0, dataFromClient.IndexOf("$"));
                        string serverResponse = "Received!";
                        Byte[] sendBytes = Encoding.ASCII.GetBytes(serverResponse);
                        networkStream.Write(sendBytes, 0, sendBytes.Length);
                        networkStream.Flush();
                    }
                    catch
                    {
                        ServerListener.Stop();
                        ServerListener.Start();
                        Invoke(DelegateTeste_ModifyText, "Server waiting connections!");
                        clientSocket = ServerListener.AcceptTcpClient();
                        Invoke(DelegateTeste_ModifyText, "Server ready!");
                    }
                }
            }
        }
    }
