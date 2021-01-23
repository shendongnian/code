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
                        new User { UserLocation = new UserLocation { LID = 2 } },
                        new User { UserLocation = new UserLocation { LID = 3 } }
                    };
    
                IEnumerable<Communication> res = communications.Where(w => users.Any(a=>a.UserLocation.LID==w.Intention.UID));
                foreach (var communication in res)
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
    
            public override string ToString()
            {
                return string.Concat("Communication-> Intention:", Intention.UID);
            }
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
    
            public UserLocation UserLocation { get; set; }
    
            #endregion
        }
    
        internal class UserLocation
        {
            #region Public Properties
    
            public int LID { get; set; }
    
            #endregion
        }
    }
