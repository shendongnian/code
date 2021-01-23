    var list = new List<string>() { "filename", "filename", "42", "another_file", "another_file" };
    foreach (var item in list.Distinct().ToArray())
    {
        var duplicates = list.Where(temp => temp == item).ToArray();
        for (int i = 0; i < duplicates.Length; i++)
        {
            duplicates[i] = string.Concat(item, (i + 1).ToString());
        }
     }
