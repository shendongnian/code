    // create a List of String that are going to be our dynamic class's properties.
    List<string> PropertyNames = new List<string>();
    PropertyNames.Add("Name");
    PropertyNames.Add("Age");
    PropertyNames.Add("Phone");
    PropertyNames.Add("Address");
    PropertyNames.Add("City");
    // Make a list of the DynamicClass
    List<DynamicClass> DynamicClassList = new List<DynamicClass>();
    // Adding 5 DynamicClass classes to the DynamicClassList
    for (int cc = 0; cc < 5; cc++ )
    {
        // declare a new DynamicClass
        var dynamicClass = new DynamicClass();
        // Give Random values to the New Properties. 
        // (because dynamicClass.property["xxx"] is of type object it could be anything.)
        // I'm just going to use random strings.
        foreach (String PropertyName in PropertyNames)
        {
            dynamicClass.property[PropertyName] = RandomString(5 + cc); // private string RandomString(int size)
        }
        // It could also have looked something like this. 
        // dynamicClass.property["Name"] = "Peter";
        // dynamicClass.property["Age"] = 25;
        // ....
        // Add the populated class to the list.
        DynamicClassList.Add(dynamicClass);
    }
    // Again I want the User to be able to select which fields (properties) they want to show in the DataGrid.
    String selectQuery = GetSelectedFields(); // private string GetSelectedFields() { return ... }
    // selectQuery will then be something like.
    selectQuery = "new (property[\"Name\"] as Name, " +
        " property[\"Age\"] as Age, " +
        " property[\"Phone\"] as Phone, " +
        " property[\"Address\"] + \" \" + property[\"City\"] as Address)";
    // Make a new DynamicClass that only contains the fields the user wants to see.
    var newDynamicClasses = DynamicClassList.AsQueryable().Select(selectQuery);
    // I Found that this was the easiest way to get the "var" back to a List, to add to the .DataSource
    // because the IQueryable above does not have a .ToList();
    List<object> newDynamicClassList = new List<object>();
    foreach (var varDynamicClass in newDynamicClasses)
    {
        newDynamicClassList.Add(varDynamicClass);
    }
    // populate the dataGridView1.DataSource with the New List of DynamicClass
    dataGridView1.DataSource = newDynamicClassList;
