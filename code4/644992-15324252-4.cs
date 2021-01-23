     public class RandomConnectionAdder
        {
            public Timer timer;
            public Random random = new Random();
    
            public Action<Connection> OnConnectionAdded { get; set; }
    
            public RandomConnectionAdder(Action<Connection> onConnectionAdded)
            {
                OnConnectionAdded = onConnectionAdded;
                timer = new Timer(x => AddConnection(), null, 5000, 2000);
            }
    
            private void AddConnection()
            {
                var computernumber = random.Next(1, 50);
                var newrandomconnection = new Connection()
                    {
                        ComputerName = "PC" + computernumber.ToString(), 
                        IPAddress = "192.168.1." + computernumber,
                        ConnectionTime = DateTime.Now
                    };
    
                if (OnConnectionAdded != null)
                    OnConnectionAdded(newrandomconnection);
            }
        }
