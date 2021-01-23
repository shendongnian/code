    // Use reflection to figure out what type of entity you need to update
    var tYourEntityType = /* your code to get the type of the object you will be working with */;
    
    // Get the entity you need to update querying based on a dynamic where clause
    string propetyNameToSeach = "firstproperty"; // set this dynamically to the name of the property
    string propertyValueToCompare = 5; // set this dynamically to the value you want to compare to
    var entityToUpdate = youDataContext.GetTable<tYourEntityType>().Where(propetyNameToSeach + " = " + propertyValueToCompare).FirstOrDefault();
