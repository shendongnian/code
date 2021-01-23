    namespace XmlParse
    {
        using System;
        using System.Collections.Generic;
        using System.Globalization;
        using System.Runtime.Serialization;
    
        [DataContract(Name = "game", Namespace = "")]
        public class Game
        {
            [DataMember(Name = "name", Order = 0)]
            public string Name { get; private set; }
    
            [DataMember(Name = "code", Order = 1)]
            public string Code { get; private set; }
    
            [DataMember(Name = "ugn", Order = 2)]
            public string Ugn { get; private set; }
    
            [DataMember(Name = "bets", Order = 3)]
            public Bets Bets { get; private set; }
        }
    
        [CollectionDataContract(Name = "bets", ItemName = "bet", Namespace = "")]
        public class Bets : List<string>
        {
            public List<decimal> BetList
            {
                get
                {
                    return ConvertAll(y => decimal.Parse(y, NumberStyles.Currency));
                }
            }
        }
    
        [CollectionDataContract(Name = "games", Namespace = "")]
        public class Games : List<Game>
        {
        }
    }
