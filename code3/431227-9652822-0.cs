    public class Test
    {
        static TournamentGame<T, Y> make16Game<T, Y>(int gameId, int seed1, int seed2, List<Y> teams)
            where T : TournamentTeam<Y>
            where Y : Team
        {
            /*
             * bunch of code removed for clarity
             */
            // return that bad boy
            return new TournamentGame<T, Y>(gameId, 
                                            new TournamentTeam<Y>(seed1, teams[seed1 - 1]),
                                            new TournamentTeam<Y>(seed2, teams[seed2 - 1]));
        }
    }
    internal class Team
    {
    }
    internal class TournamentTeam<T>
    {
        public TournamentTeam(int seed1, Team team)
        {
            throw new NotImplementedException();
        }
    }
    internal class TournamentGame<T, Y>
    {
        public TournamentGame(int gameId, TournamentTeam<Y> tournamentTeam, TournamentTeam<Y> tournamentTeam1)
        {
            throw new NotImplementedException();
        }
    }
