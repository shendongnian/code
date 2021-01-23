    DbEntityEntry entry = context.Entry(yourEntity);
    //Gets latest values of entity from the database
    var propertyValues = entry.GetDatabaseValues();
    //Fills an entity object with database values(except navigational properties)
    dynamic newEntity = propertyValues.ToObject();
    //Manually loading the needed navigational properties and handling add/removes.
    foreach (var prop in propertyValues.PropertyNames)
    {
        //either a collection<int> or an int.
        var idOfReferencedElement = propertyValues.GetValue<int>(foreignKeyField);
        //remember to handle add/removes too.
        newEntity.[thePropertyYouKnowExist] = context.[theDBSet].Find(idOfReferencedElement);
    }
