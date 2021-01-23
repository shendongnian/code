    var test = new List<string>();
    for (int i = 0; i < 59; i++)
    {
        test.Add("Test" + i);   
    }
    var result = divStrings(10, test.ToArray());
