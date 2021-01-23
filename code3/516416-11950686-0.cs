      public static readonly ConcurrentDictionary<string ,object> _connections = new 
      ConcurrentDictionary<string,object>();
        public Task Connect()
        {
                _connections.TryAdd(Context.ConnectionId, null);
                Groups.Add(Context.ConnectionId, "users");
                //Returns Connection count. 
                return Clients.tally(_connections.Count.ToString());
            
        }
