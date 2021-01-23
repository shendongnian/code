    var player = new Player()
        {
            PlayerBaseballStat = new PlayerBaseballStat()
            {
                BaseballStats = new Collection<BaseballStat>()
                {
                    new BaseballStat()
                    { 
                        StatName = "ERA", 
                        StatValue = 1.41M, 
                        Year = 2011
                    }                                            
                }
            }
        };
        context.Players.Add(player);
        context.SaveChanges();
