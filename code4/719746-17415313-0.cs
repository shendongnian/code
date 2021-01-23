    string[] searchTerms = "Jordan Sparks 88".Split(' ');
    using (var dc = new MyDataContext())
    {
        //Using DataContext.Log is handy 
        //if we want to look at Linq2SQL's generated SQL:
        dc.Log = new System.IO.StringWriter();
        //Prepare to build a "players" query:
        IQueryable<Player> playersQuery = dc.Players;
        foreach (var term in searchTerms)
        {
            //Refine our query, one search term at a time:
            playersQuery = playersQuery.Where(p => p.firstName.Contains(term) ||
                                                   p.lastName.Contains(term) ||
                                                   p.playersNum.Contains(term));
        }
        //Now we have the complete query. Get the results from the database:
        var filteredPlayers = playersQuery.ToArray();
        //See if the generated SQL looked like it was supposed to:
        var sql = dc.Log.ToString();
    }
