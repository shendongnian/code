    public class SearchClass
    {
        public string userId { get; set; }
        public string email { get; set; }
        public string lastFourdigits { get; set; }
    
        public static List<SearchClass> Users(string userId, string email, string lastFourdigits)   
        {
            SearchClass Alex = new SearchClass();
            Alex.userId = "1234";
            Alex.email = "Alex@gmail.com";
            Alex.lastFourdigits = "1885";
    
            SearchClass Emilio = new SearchClass();
            Emilio.userId = "0928";
            Emilio.email = "Cubano@gmail.com";
            Emilio.lastFourdigits = "0706";
    
            SearchClass Ulysses = new SearchClass();
            Ulysses.userId = "0914";
            Ulysses.email = "lysses@gmail.com";
            Ulysses.lastFourdigits = "01zx";
    
            var list = new List<SearchClass>();
            list.Add(Alex);
            list.Add(Emilio);
            list.Add(Ulysses);
            IEnumerable<SearchClass> result = list;
            if(!string.IsNullOrEmpty(userId))
                result = result.Where(u => u.userId == userId);
            if(!string.IsNullOrEmpty(email))
                result = result.Where(u => u.email == email);
            if(!string.IsNullOrEmpty(lastFourdigits))
                result = result.Where(u => u.lastFourdigits == lastFourdigits);
            return result.ToList();
        }
