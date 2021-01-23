    MyResult result = GetResult();
    result.MyList = new List<string>();
    foreach (IFieldable field in doc.GetFields())
    {
        if (field.Name == "ID")
        {
            result.ID = int.Parse(field.StringValue);
        }
        else if (field.Name == "myList")
        {
            result.MyList.Add(field.StringValue);
        }
    }
