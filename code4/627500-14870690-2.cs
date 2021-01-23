    var inputList = new List<string>
        {
            "Item 1: #item1#",
            "Item 2: #item2#",
            "Item 3: #item3#",
            "Item 4: item4"
        };
    var outputList = inputList
        .Select(item =>
            {
                int startPos = item.IndexOf('#');
                if (startPos < 0)
                    return item;
                int endPos = item.IndexOf('#', startPos + 1);
                if (endPos < 0)
                    return item;
                return item.Substring(startPos, endPos - startPos + 1);
            })
        .ToList();
