    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    class Organisation
    {
        public string LogoUrl { get; set; }
        // Removed redundant Organisation prefixes
        public int Id { get; set; }
        public string Name { get; set; }
    }
    
    class Test
    {
        static void Main()
        {
            // Used collection initializer for sanity
            var list = new List<Organisation>
            {
                new Organisation { LogoUrl = "Blade.png", Id = 1, Name = "Blade" },
                new Organisation { LogoUrl = "Torn.png", Id = 2, Name = "Torn" },
            };
    
            string searchString = "Tor";
            var query = from org in list
                        where org.Name.StartsWith(searchString)
                        select org;
            
            // Nicer version:
            // var query = list.Where(org => org.Name.StartsWith(searchString));
            
            Console.WriteLine(query.Count()); // 1
        }
    }
