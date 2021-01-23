    static void Main(string[] args)
    {
        try
        {
            byte[] input = new byte[]{1};
            byte[] buffer = new byte[4096];
            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Raw, ProtocolType.IP);
            s.Bind(new IPEndPoint(IPAddress.Broadcast, 80));
            s.IOControl(IOControlCode.ReceiveAll , input, null);
            s.BeginReceive(arrResponseBytes, 0, arrResponseBytes.Length, SocketFlags.None, new AsyncCallback(OnClientReceive), s);
            System.Threading.ManualResetEvent reset = new System.Threading.ManualResetEvent(false);
            reset.WaitOne();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
        Console.ReadKey();
    }
    static byte[] arrResponseBytes = new byte[1024 * 64];
    static void OnClientReceive(IAsyncResult ar)
    {
        Socket socket = (Socket)ar.AsyncState;
        int count = socket.EndReceive(ar);
        if (count >= 40)
        {
            try
            {
                string s = Encoding.UTF8.GetString(arrResponseBytes, 40, count - 40);
                string bin = BitConverter.ToString(arrResponseBytes, 40, count - 40).Replace("-", " ");
                if(s.StartsWith("GET"))
                    Console.WriteLine(s + " - " + bin);
                //Thread.Sleep(1000);
            }
            catch { }
        }
        socket.BeginReceive(arrResponseBytes, 0, arrResponseBytes.Length, SocketFlags.None, new AsyncCallback(OnClientReceive), socket);
    }
