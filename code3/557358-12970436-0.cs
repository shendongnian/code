     try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();
                List<Bet> bets = new List<Bet>();
                using(MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)){
                
                while (dr.Read())
                {
                    Bet myBet = new Bet();
                    myBet = FillBetfromRow(dr);
                    bets.Add(myBet);
                }
           }
                return bets;
            }
