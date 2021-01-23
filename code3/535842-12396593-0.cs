    public Form1() 
        { 
            InitializeComponent(); 
            List<MyClient> clients = new List<MyClient>(); 
            clients.Add(new MyClient { ClientName = "Client 1", UrlAddress = @"http://www.google.com" });
            foreach(MyClient client in clients)
            {
                BigClients.Items.Add(client);
            } 
        }
