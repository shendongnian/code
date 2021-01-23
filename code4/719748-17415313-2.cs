    string[] searchTerms = "Jordan Sparks 88".Split(' ');
    using (var dc = new MyDataContext())
    {
        //Using DataContext.Log is handy 
        //if we want to look at Linq2SQL's generated SQL:
        dc.Log = new System.IO.StringWriter();
        //Prepare to build a "players" query:
        IQueryable<Player> playersQuery = dc.Players;
        //Refine our query, one search term at a time:
        foreach (var term in searchTerms)
        {
            //Create (and use) a local variable of the search term
            //to avoid the "outer variable trap":
            //http://stackoverflow.com/questions/3416758
            //http://stackoverflow.com/questions/295593
            var currentTerm = term.Trim();
            playersQuery = playersQuery.Where(p => (p.isDeleted == false)
                                                    &&
                                                   (p.FirstName.Contains(currentTerm) ||
                                                    p.LastName.Contains(currentTerm) ||
                                                    p.PlayersNumber.Contains(currentTerm) ||
                                                    p.Team.Name.Contains(currentTerm))
                                                );
        }
        //Now we have the complete query. Get the results from the database:
        var filteredPlayers = playersQuery.Select(p => new
                                                       {
                                                           p.idPlayer,
                                                           p.FirstName,
                                                           p.LastName,
                                                           p.PlayersNumber,
                                                           TeamName = p.Team.Name
                                                       })
                                          .ToArray();
        //See if the generated SQL looked like it was supposed to:
        var sql = dc.Log.ToString();
    }
