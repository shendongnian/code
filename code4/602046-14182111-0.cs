    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace SOPlayersOrder
    {
        class Program
        {
            public class MatchUp
            {
                public string Player1 { get; set; }
                public string Player2 { get; set; }
    
                public override string ToString()
                {
                    return string.Format("{0} vs {1}", Player1, Player2);
                }
            }
    
            public static IEnumerable<MatchUp> PairPlayers(List<string> players)
            {
                var results = new List<MatchUp>();
                for (int i = 0; i < players.Count - 1; i++)
                {
                    for (int j = i + 1; j < players.Count; j++)
                    {
                        var matchup = new MatchUp { Player1 = players[i], Player2 = players[j] };
                        //yield return matchup; //this is how Jon Skeet suggested, I am showing you "eager" evaluation
                        results.Add(matchup);
                    }
                }
                return results;
            }
    
            public static IEnumerable<MatchUp> OrganiseGames(IEnumerable<string> players, IEnumerable<MatchUp> games)
            {
                var results = new List<MatchUp>();
                //a list that we will treat as a queue - most recently played at the back of the queue
                var playerStack = new List<string>(players);
                //a list that we can modify
                var gamesList = new List<MatchUp>(games);
                while (gamesList.Count > 0)
                {
                    //find a game for the top player on the stack
                    var player1 = playerStack.First();
                    var player2 = playerStack.Skip(1).First();
                    //the players are in the order of least recently played first
                    MatchUp matchUp = FindFirstAvailableGame(playerStack, gamesList);
                    //drop the players that just played to the back of the list
                    playerStack.Remove(matchUp.Player1);
                    playerStack.Remove(matchUp.Player2);
                    playerStack.Add(matchUp.Player1);
                    playerStack.Add(matchUp.Player2);
                    //remove that pairing
                    gamesList.Remove(matchUp);
                    //yield return matchUp; //optional way of doing this
                    results.Add(matchUp);
                }
                return results;
            }
    
            private static MatchUp FindFirstAvailableGame(List<string> players, List<MatchUp> gamesList)
            {            
                for (int i = 0; i < players.Count - 1; i++)
                {
                    for (int j = i + 1; j < players.Count; j++)
                    {
                        var game = gamesList.FirstOrDefault(g => g.Player1 == players[i] && g.Player2 == players[j] ||
                                                                 g.Player2 == players[i] && g.Player1 == players[j]);
                        if (game != null) return game;
                    }
                }
                throw new Exception("Didn't find a game");
            }
    
            static void Main(string[] args)
            {
                var players = new List<string>(new []{"A","B","C","D","E"});
                var allGames = new List<MatchUp>(PairPlayers(players));
    
                Console.WriteLine("Unorganised");
    
                foreach (var game in allGames)
                {
                    Console.WriteLine(game);
                }
    
                Console.WriteLine("Organised");
    
                foreach (var game in OrganiseGames(players, allGames))
                {
                    Console.WriteLine(game);
                }
                Console.ReadLine();
            }
        }
    }
