    string username = "userfoo";
    string password = "passwordfoo";
    
    Parallel.For(0, 2000; i =>
    {    
        uint matchId;
        if (!uint.TryParse(i.ToString(), out matchId))
        {
            Console.WriteLine("Invalid Match ID!");
            return;
        }
    
        Client client = new Client (username, password, matchId);
    
        // connect
        client.Connect();
    
        client.Wait();
    
        if (client.Match != null)
        {
            Console.WriteLine("Inserting match: #{0}", client.Match.match_id);
            Helpers.MatchHelper.AddMatchToDatabase(client.Match);
        }
        else
        {
            Console.WriteLine("Couldn't get match: #{0}", 1);
        }
    
    
    });
