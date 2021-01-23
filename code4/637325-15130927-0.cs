    List<String> list = new List();
    ....
     for (int i = 0; i < Counter; i++)
     {
         list.Add(result[i].department.ToString());
     }
     var noDuplicates = list.Distinct();
