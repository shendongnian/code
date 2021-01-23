    var newTask = new Entity("Task");
    newTask.Attributes.Add("subject", "foo");
    // etc etc for other common properties
    if (context.PrimaryEntityName.Equals("new_entitya"))
    {
        newTask.Attributes.Add("new_optionset", valueA);
    }
    else
    {
        newTask.Attributes.Add("new_optionset", valueB);
    }
    
