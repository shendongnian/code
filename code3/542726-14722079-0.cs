    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    
    using Starksoft.Net.Proxy;
    
    using System.IO;
    using System.Net.Sockets;
    using System.Net;
    using System.Web;
    
    using System.Threading;
    
    namespace networking
    {
        namespace client
        {
    
            internal class proxy
            {
                public struct conn
                {
                    internal TcpClient http;
                    internal IProxyClient Proxy;
                    public ProxyType proxy_type;
    
                    public string proxy_host;
                    public int proxy_port;
                    public string target_host;
                    public int target_port;
                    public string recv_packet;
    
                    public void proxy_config(string target_host, int target_port, string proxy_host, int proxy_port, ProxyType type)
                    {
                        this.target_host = target_host; this.target_port = target_port;
                        this.proxy_host = proxy_host; this.proxy_port = proxy_port;
                        this.proxy_type = type;
                    }
                }
                public conn proxy_conn;
                internal proxy(string target_host, int target_port, string proxy_host, int proxy_port, ProxyType type)
                {
                    Console.WriteLine("Socket allocated.");
                    this.proxy_conn = new proxy.conn();
                    this.proxy_conn.proxy_config(target_host, target_port, proxy_host, proxy_port, type);
                    ProxyClientFactory factory = new ProxyClientFactory();
                    this.proxy_conn.Proxy = factory.CreateProxyClient(type, proxy_host, proxy_port);
                    this.proxy_conn.Proxy.CreateConnectionAsyncCompleted += new EventHandler<CreateConnectionAsyncCompletedEventArgs>(proxy_connected);
                    
                    //this.Proxy.CreateConnectionAsync(obj.target_host, obj.target_port);
                }
                internal void connect()
                {
                    this.proxy_conn.Proxy.CreateConnectionAsync(this.proxy_conn.target_host, this.proxy_conn.target_port);
                }
                private void proxy_connected(object sender, CreateConnectionAsyncCompletedEventArgs e)
                {
                    if (e.Error != null)
                    {
                        Console.WriteLine("Connection Error!");
                        Console.WriteLine(e.Error.Message);
                        return;
                    }
                    else if (e.Error == null)
                    {
                        // get a reference to the open proxy connection
                        Console.WriteLine("Connected to Tor!");
                        this.proxy_conn.http = e.ProxyConnection;
                        Console.WriteLine("Proxy referenced.");
                    }
                }
                public void send(string data)
                {
                    this.proxy_conn.http.Client.Send(ASCIIEncoding.ASCII.GetBytes(data));
                }
                public string recv()
                {
                    byte[] rcvBuffer = new byte[1024]; //1024
                    int bytes = this.proxy_conn.http.Client.Receive(rcvBuffer, 1024, SocketFlags.None);
                    this.proxy_conn.recv_packet += ASCIIEncoding.ASCII.GetString(rcvBuffer, 0, bytes);
                    return this.proxy_conn.recv_packet;
                }
    
            }
    
            internal class Tor
            {
                private static Tor instance;
    
                private Process tor;
                //private conn obj_conn;
                private Tor(){}
                internal static Tor Instance
                {
                    get
                    {
                        if (instance == null)
                        {
                            instance = new Tor();
                        }
                        return instance;
                    }
                }
                internal void tor_start()
                {
                    if (this.tor == null)
                    {
                        Console.WriteLine("Tor init...");
                        this.tor = new Process();
                        this.tor.StartInfo.FileName = "tor.exe";
                        this.tor.StartInfo.WorkingDirectory = Directory.GetCurrentDirectory();
                        Console.WriteLine(Directory.GetCurrentDirectory());
                        this.tor.StartInfo.CreateNoWindow = false;
                        this.tor.StartInfo.UseShellExecute = false;
                        this.tor.StartInfo.RedirectStandardOutput = true;
                        this.tor.StartInfo.RedirectStandardInput = true;
                        this.tor.StartInfo.RedirectStandardError = true;
                        this.tor.OutputDataReceived += new DataReceivedEventHandler((sender, args) => { stdout__tor(sender, args); });
                        this.tor.ErrorDataReceived += new DataReceivedEventHandler((sender, args) => { stderr__tor(sender, args); });
    
                        this.tor.Start();
                        Console.WriteLine("Strapping input...");
                        this.tor.BeginOutputReadLine();
                        this.tor.BeginErrorReadLine();
                    }
                    else
                    {
                        Console.WriteLine("A Tor process already exists.");
                    }
                    
                }
                internal void tor_stop()
                {
                    this.tor.StandardOutput.Close();
                    this.tor.StandardInput.Close();
                    this.tor.StandardError.Close();
                    this.tor.Kill();
                    this.tor.Dispose();
                    this.tor = null;
                }
                internal void tor_restart()
                {
                    tor_stop();
                    tor_start();
                }
                private void stdout__tor(object sender, DataReceivedEventArgs pipe)
                {
                    if (pipe.Data.Contains("Bootstrapped 100%: Done."))
                    {
                        Console.WriteLine("Tor has been initialized.");
                        //this.obj_conn.Proxy.CreateConnectionAsync(obj_conn.target_host, obj_conn.target_port);
                    }
                    Console.WriteLine(pipe.Data);
                }
                private void stderr__tor(object sender, DataReceivedEventArgs pipe)
                {
                    Console.WriteLine("[ERROR]: " + pipe.Data);
                }
            }
    
            
        }
    
    
        public class socket
        {
            internal static client.Tor Tor_obj;
            internal static List<client.proxy> proxy_socks;
    
            public socket()
            {
                if (Tor_obj == null || proxy_socks == null)
                {
                    if (Tor_obj == null)
                    {
                        Tor_obj = client.Tor.Instance;
                        Tor_obj.tor_start();
                    }
                    if (proxy_socks == null)
                    {
                        proxy_socks = new List<client.proxy>();
                    }
                }
            }
            public int add(string type, string host, int port)
            {
                int index = -1;
                if (type == "proxy")
                {
                    proxy_socks.Add(new client.proxy(host, port, "127.0.0.1", 9050, ProxyType.Socks4a));
                    index = proxy_socks.Count() - 1;
                    proxy_socks[index].connect();
                    return index;
                }
                return index;
    
                }
        }
    }
    
    namespace myprog
    {
        class Program
        {
            static void Main(string[] args)
            {
    
                networking.socket connections = new networking.socket();
                Thread.Sleep(20000);
                int conn_index = connections.add("proxy", "checkmyip.com", 80);
                Thread.Sleep(10000);
                networking.socket.proxy_socks[conn_index].send("GET / HTTP/1.1\r\nHost: checkmyip.com\r\n\r\n");
                Console.WriteLine(WebUtility.HtmlDecode(networking.socket.proxy_socks[conn_index].recv()));
                Thread.Sleep(50000);
            }
        }
    }
