    class Program
    {
        static void Main(string[] args)
        {
            BasketballTeam bt = new BasketballTeam("MyTeam");
            BasketballPlayer bp = new BasketballPlayer("Bob");
    
            bt.AddPlayer(bp);
    
            foreach (BasketballPlayer player in bt.Players)
            {
                Console.WriteLine(player.Name);
            }
    
            foreach (IAthlete a in bt.Players)
            {
                Console.WriteLine(a.Name);
            }
        }
    }
