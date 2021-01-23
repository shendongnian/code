     public List<MessageElement> BuildTree(IEnumerable<string> strings)
                {
                    return (
                      from s in strings
                      let split = s.Split('.')
                      group s by s.Split('.')[0] into g
                      select new MessageElement    // <-- Pass in ID here?
                      {
                          Name = g.Key,
                          Children = BuildTree(
                            from s in g
                            where s.Length > g.Key.Length + 1
                            select s.Substring(g.Key.Length + 1))
                      }
                      ).ToList();
    
        }
