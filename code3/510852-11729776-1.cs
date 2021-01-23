    namespace CollectionsWithIntentions
    {
        using System.Collections.Generic;
        using System.Diagnostics;
        using System.Linq;
    
        internal class Program
        {
            #region Methods
    
            private static void Main(string[] args)
            {
                var communications = new[]
                    {
                        new Communication { Intention = new Intention { UID = 1 } },
                        new Communication { Intention = new Intention { UID = 2 } },
                        new Communication { Intention = new Intention { UID = 3 } },
                        new Communication { Intention = new Intention { UID = 4 } },
                    };
                var users = new[]
                    {
                        new User { UserLocations = new List<UserLocation>(new[] { new UserLocation { LID = 2 },new UserLocation{LID=5}  }) },
                        new User { UserLocations = new List<UserLocation>(new[] { new UserLocation { LID = 3 } }) }
                    };
    
                IEnumerable<Communication> res =
                    communications.Where(w => users.Any(a => a.UserLocations.Any(b=>b.LID == w.Intention.UID)));
                foreach (Communication communication in res)
                {
                    Trace.WriteLine(communication);
                }
            }
    
            #endregion
        }
    
        internal class Communication
        {
            #region Public Properties
    
            public Intention Intention { get; set; }
    
            #endregion
    
            #region Public Methods and Operators
    
            public override string ToString()
            {
                return string.Concat("Communication-> Intention:", this.Intention.UID);
            }
    
            #endregion
        }
    
        internal class Intention
        {
            #region Public Properties
    
            public int UID { get; set; }
    
            #endregion
        }
    
        internal class User
        {
            #region Public Properties
    
            public List<UserLocation> UserLocations { get; set; }
    
            #endregion
        }
    
        internal class UserLocation
        {
            #region Public Properties
    
            public int LID { get; set; }
    
            #endregion
        }
    }
