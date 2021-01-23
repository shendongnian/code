    protected override void UnloadContent()
        {
            
            // TODO: Unload any non ContentManager content here            
            if (client != null)
                client.Close(); // I exist so close the connection...
            // I would place a timout on the server side 
            // client.Available as well to drop inactive clients...
            System.Threading.Thread.Sleep(3000); // Force the Client to stay open long enough to communicate a closure...          
        }
