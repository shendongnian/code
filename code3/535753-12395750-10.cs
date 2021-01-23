                personDefault pd1 = new personDefault("John");
                personDefault pd2 = new personDefault("John");
                if (pd1 == pd2)  // return false
                {
                    System.Diagnostics.Debug.WriteLine("pd1 == pd2");
                }
                List<personDefault> personsDefault = new List<personDefault>();
                personsDefault.Add(pd1);
                if (personsDefault.Contains(pd2))  // returns false
                {
                    System.Diagnostics.Debug.WriteLine("Contains(pd2)");
                }
    
                personOverRide po1 = new personOverRide("John");
                personOverRide po2 = new personOverRide("John");
                System.Diagnostics.Debug.WriteLine(po1.GetHashCode().ToString());
                System.Diagnostics.Debug.WriteLine(po2.GetHashCode().ToString());
                if (po1.Equals(po2))  // return true
                {
                    System.Diagnostics.Debug.WriteLine("po1 == po2");
                }
                List<personOverRide> personsOverRide = new List<personOverRide>();
                personsOverRide.Add(po1);
                if (personsOverRide.Contains(po2))  // returns true
                {
                    System.Diagnostics.Debug.WriteLine("Contains(p02)");
                }
            }
    
    
    
            public class personDefault
            {
                public string Name { get; private set; }
                public personDefault(string name) { Name = name; }
            }
    
            public class personOverRide: Object
            {
                public string Name { get; private set; }
                public personOverRide(string name) { Name = name; }
    
                public override bool Equals(Object obj)
                {
                    //Check for null and compare run-time types.
                    if (obj == null || !(obj is personOverRide)) return false;
                    personOverRide item = (personOverRide)obj;
                    return (Name == item.Name);
                }
                public override int GetHashCode()
                {
                    return Name.GetHashCode();
                }
            }
