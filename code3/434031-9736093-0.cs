       //I've changed my console application to Winform
       public ServerDiscovery()
        {
            InitializeComponent();
            timer.Elapsed += timer_tick;
        }
        System.Timers.Timer timer = new System.Timers.Timer(5000);
        List<SocketAsyncEventArgs> list = new List<SocketAsyncEventArgs>();
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            timer.Start();
            Parallel.For(1, 255, (i, loopState) =>
            {
                ConnectTo("192.168.1." + i);
            });
        }
        private void ConnectTo(string ipAdd)
        {
            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            SocketAsyncEventArgs e = new SocketAsyncEventArgs();
            e.RemoteEndPoint = new IPEndPoint(IPAddress.Parse(ipAdd), 9990);
            e.UserToken = s;
            e.Completed += new EventHandler<SocketAsyncEventArgs>(e_Completed);
            list.Add(e);      // Add to a list so we dispose all the sockets when the timer ticks.
            s.ConnectAsync(e);
        }
        private void e_Completed(object sender, SocketAsyncEventArgs e)
        {
            if (e.ConnectSocket != null)     //if there's a connection Add its info to a listview
            {
                StreamReader sr = new StreamReader(new NetworkStream(e.ConnectSocket));
                ListViewItem item = new ListViewItem();
                item.Text = sr.ReadLine();
                item.SubItems.Add(((IPEndPoint)e.RemoteEndPoint).Address.ToString());
                item.SubItems.Add("Online");
                AddServer(item);
            }
        }
        delegate void AddItem(ListViewItem item);
        private void AddServer(ListViewItem item)
        {
            if (InvokeRequired)
            {
                Invoke(new AddItem(AddServer), item);
                return;
            }
            listServer.Items.Add(item);
        }
        private void timer_tick(object sender, EventArgs e)
        {
            timer.Stop();
            foreach (var s in list)
            {
                ((Socket)s.UserToken).Dispose();     //disposing all sockets that's pending or connected.
            }
        }
