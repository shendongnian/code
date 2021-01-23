    var dictionary = new Dictionary<string, object>();
    dictionary.Add("Name", "Ilya");
    
    
    dynamic dyn = new ExpandoObject();
    var expandoDic = (IDictionary<string, object>)dyn;
    
    dictionary.ToList()
              .ForEach(keyValue => expandoDic.Add(keyValue.Key, keyValue.Value));
    
    Console.WriteLine(dyn.Name); //prints Ilya
