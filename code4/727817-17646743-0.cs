    var lines = File.ReadLines("c:\\StackOverflow.txt");
    List<User> results = new List<User>();
    bool titleFound = false;
    User current = null;
    foreach (var line in lines)
    {
        if (line.StartsWith("Title"))
        {
            titleFound = true;
            current = new User { Alias = new List<string>() };
            current.Title = line;
        }
        if (titleFound)
        {
            if (line.StartsWith("alias"))
            {
                current.Alias.Add(line);
            }
            if (line.StartsWith("Salutation"))
            {
                current.Salutation = line;
                results.Add(current);
                titleFound = false;
            }
        }
    }
    public class User
    {
        public string Title { get; set; }
        public List<string> Alias  { get; set; }
        public string Salutation  { get; set; }
    }
