        List<string> elements = new List<string>();
        foreach (var item in responseList)
        {
            if (item.Response != 0)
            {
                elements.add(item.AliasName + "|" + item.CellPhoneNumber + "|" + item.Response.ToString());
            }
        }
        string result = string.Join(",", elements.ToArray());
    
