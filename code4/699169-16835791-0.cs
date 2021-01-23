    using System.Collections.Generic;
    namespace App.Toolkit.Parameter
    {
    public class League : SearchParameterBase<uint>
    {
        public const uint BarclaysPremierLeague = 13;
        public const uint Bundesliga = 19;
        public const uint LigaBbva = 53;
        public const uint Ligue1 = 16;
        public const uint SerieA = 31;
        private League(string description, uint value)
        {
            Description = description;
            Value = value;
        }
       
        public static IEnumerable<League> GetAll()
        {
            yield return new League("Barclays Premier League", BarclaysPremierLeague);
            yield return new League("Bundesliga", Bundesliga);
            yield return new League("Liga BBVA", LigaBbva);
            yield return new League("Ligue 1", Ligue1);
            yield return new League("Serie A", SerieA);
        }
        public override string ToString()
        {
            return Description;
        }
      }
    }    
