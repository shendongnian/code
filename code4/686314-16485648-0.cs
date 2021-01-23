       private void But_rnd_Click(object sender, EventArgs e)
        {
            LoadPlayers();
            List<string> results=new List<string>();
            Grouping(ref results);
            ShowResults(ref results);
        }
    
        private void Grouping(ref List<string> results)
        {
            Random r=new Random();
            while (Players.count() > 1)
            {
               int p1 = r.next(players.count());
               String p1s = players.get(p1);
               players.removeat(p1);
               int p2 = r.next(players.count());
               String p2s = players.get(p2);
               players.removeat(p2);
    
               results.add(//whatever string you use to combine p1 + p2);
            }
            if (players.count() > 0)
            {
                // add remaining players
            }
        }
    
