    DefinedNames definedNames = new DefinedNames();    //Create the collection
    DefinedName definedName = new DefinedName()
        { Name = "List", Text="mysheet!$A$1:$A$1" };   // Create a new range (name matching the QueryTable name) 
    definedNames.Append(definedName);                  // Add it to the collection
    workbookpart.Workbook.Append(definedNames);        // Add collection to the workbook
