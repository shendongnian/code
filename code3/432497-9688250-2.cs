    var lists = new List<List<string>>();
    lists.Add(new List<String>(new[] { "A", "B", "C" }));
    lists.Add(new List<String>(new[] { "D", "E", "F", "G" }));
    lists.Add(new List<String>(new[] { "H", "I", "J", "K", "L" }));
    var all = lists.SelectMany(i => i);
    String allLetters= String.Format("All letters: {0}",String.Join(",",all));
