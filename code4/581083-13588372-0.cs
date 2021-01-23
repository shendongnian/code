    var myBindings = System.Reflection.BindingFlags.Instance
            | System.Reflection.BindingFlags.Public 
            | System.Reflection.BindingFlags.SetProperty;
    
    foreach (var row in table.AsEnumerable())
    {
        MyClass newObject = new MyClass();
        foreach (var property in typeof(MyClass).GetProperties(myBindings))
        {
            if (table.Columns.Contains(property.Name))
            {
                //optionally verify that the type of the property matches what's in the datatable
                property.SetValue(newObject, row[property.Name]);
            }
        }
        //add newObject to result collection
    }
