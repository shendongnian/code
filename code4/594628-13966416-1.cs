    List<string> myList = new List<string> { 
        "{ Name = \"Foo\" }",
        "{ Name = \"Bar\" }",
        "{ Name = \"Car\" }"
    };
    var temp = myList.Select(x =>
        {
            int index = x.IndexOf("\"") + 1;
            return x.Substring(index, x.LastIndexOf("\"") - index);
        })
        .ToList();
    string result = string.Format("{0} and {1}.",
                                  string.Join(", ", temp.Take(myList.Count - 1)),
                                  temp.Last());
