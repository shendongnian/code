    public ServerDiscovery()
        {
            InitializeComponent();
        //    statusLabel.Image = imageState.Images[2];
            timer.Elapsed += timer_tick;
        }
        int port = 0;
        bool busy = false;  // to tell that the function is busy with scanning.
        public void Initialize(int port)
        {
            this.port = port;
        }
        
        System.Timers.Timer timer = new System.Timers.Timer(5000);
        List<SocketAsyncEventArgs> list = new List<SocketAsyncEventArgs>();
        // this list to hold all sockets that created to connect to IP .. to DISPOSE it later
        HashSet<string> usedIP = new HashSet<string>();
        //usedIP will be explained later. 
        public IPEndPoint getAddress()
        {   //this function to get the IPEndPoint of the selected server from listview.
            if (listServer.SelectedItems.Count > 0)
            {
                if (listServer.SelectedItems[0].ImageIndex == 0)
                {
                    ListViewItem item = listServer.SelectedItems[0];
                    IPEndPoint ep = new IPEndPoint(IPAddress.Parse(item.SubItems[1].Text), port);
                    return ep;
                }
            }
            return null;
        }
        public void Refresh()   //to scan for servers
        {
            if (!busy)
            {
                usedIP.Clear();
                listServer.Items.Clear();
        //       statusLabel.Text = "Scanning for servers.";
        //        statusLabel.Image = Image.FromFile("loading.gif");
        //        btnRefresh.Enabled = false;
                busy = true;
                timer.Start();
                IPAddress[] IpA = Dns.GetHostByName(Dns.GetHostName()).AddressList;
                for (int j = 0; j < IpA.Length ; j++)
                {
                    if (IpA[j].AddressFamily == AddressFamily.InterNetwork)  // to make sure it's an IPV4
                    {
                        string scanIP = IpA[j].ToString().Substring(0, IpA[j].ToString().LastIndexOf(".")) + ".";
                        if (!usedIP.Contains(scanIP))
                 //usedIP is a hashset that holds the first 3 parts on an ip (ex:"192.168.1." from "192.168.1.30") i used this to avoid scanning the same ip addresses more than once .. like if i had a wireless network ip ("192.168.1.5") and an Ethernet Network ip ("192.168.1.5"). so with that hashset it will scan once.
                        {
                            usedIP.Add(scanIP);
                            Parallel.For(1, 255, i =>
                            {
                                Scan(scanIP + i);
                            });
                        }
                    }
                }
            }
        }
        private void Scan(string ipAdd)
        {
            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            SocketAsyncEventArgs e = new SocketAsyncEventArgs();
            e.RemoteEndPoint = new IPEndPoint(IPAddress.Parse(ipAdd), port);
            e.UserToken = s;
            e.Completed += new EventHandler<SocketAsyncEventArgs>(e_Completed);
            list.Add(e);   // add the created socket to a list to dispose when time is up.
            s.ConnectAsync(e);
        }
        private void e_Completed(object sender, SocketAsyncEventArgs e)
        {
            if (e.ConnectSocket != null) //if there's a responce from the server [e.ConnectSocket] will not be equal null.
            {
                StreamReader sr = new StreamReader(new NetworkStream(e.ConnectSocket));
                ListViewItem item = new ListViewItem();
                string[] cmd = sr.ReadLine().Split('<');  in my server constructor this line will receive a string like "PC_NAME<Available"  ..
                item.Text = cmd[0];
                item.SubItems.Add(((IPEndPoint)e.RemoteEndPoint).Address.ToString());
                item.SubItems.Add(cmd[1]);
                if (cmd[1] == "Busy")
                    item.ImageIndex = 1;
                else
                    item.ImageIndex = 0;
                AddServer(item);
                list.Remove(e);  //active server should be remove from the list that holds the sockets and disposed.. because there's no need to keep connection after showing that this server is active. 
                ((Socket)e.UserToken).Dispose();
            }
        }
        delegate void AddItem(ListViewItem item);
        private void AddServer(ListViewItem item)
        {
            if (InvokeRequired)
            {
                Invoke(new AddItem(AddServer), item);  //just to add an item from a background thread.
                return;
            }
            listServer.Items.Add(item);
        }
        private void timer_tick(object sender, EventArgs e)
        {
            busy = false;     //when time's up .. set busy to false so we can scan again
            timer.Stop();
            foreach (var s in list) //dispose all sockets that's trying to connect and waiting for a response
            {
                try
                {
                    ((Socket)s.UserToken).Dispose();
                }
                catch { }
            }
            //this.Invoke((MethodInvoker)delegate        // for design
           // {
           //     btnRefresh.Enabled = true;
           //     btnRefresh.BorderStyle = Border3DStyle.Raised;
           //     statusLabel.Text = "Ready.";
           //     statusLabel.Image = imageState.Images[2];
           // });
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
           // btnRefresh.BorderStyle = Border3DStyle.Sunken;
            Refresh();
        }
       // private void listServer_KeyUp(object sender, KeyEventArgs e)
       // {
        //    if (e.KeyCode == Keys.F5)
        //    {
         //       btnRefresh_Click(sender, (EventArgs)e);
         //   }
      //  }
        
    }
