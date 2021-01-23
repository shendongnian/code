    public enum types
        {
            Type1,
            Type2,
            Type3
        }
    
        public class GenericListing
        {
            public string Description { get; set; }
            public types Type { get; set; }
        }
    
        class Program
        {
            public static List<GenericListing> GetTypeListing(List<GenericListing> aListings, types aTypes)
            {
                return aListings.Where(x => x.Type == aTypes).ToList();
            }
    
            static void Main(string[] args)
            {
                var stuff = new List<GenericListing>
                    {
                        new GenericListing {Description = "I am number 1", Type = types.Type1},
                        new GenericListing {Description = "I am number 2", Type = types.Type2},
                        new GenericListing {Description = "I am number 3", Type = types.Type3},
                        new GenericListing {Description = "I am number 1 again", Type = types.Type1},
                    };
    
    
                string s = "";
    
                GetTypeListing(stuff, types.Type1)  // Get a specific type but require a well typed input.
                    .ForEach(n => s += n.Description + "\tType: " + n.Type + Environment.NewLine);
    
                Console.WriteLine(s);
    
                Console.ReadLine();
            }
        }
