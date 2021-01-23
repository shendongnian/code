    using System.Collections.Generic;
    using System.Linq;
    
    class Test
    {
        static void Main()
        {
            var emptyList = new List<string>();
            var aha = emptyList.Where(i => i == "four"); 
            var props = aha.First();
        }
    }
