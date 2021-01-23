    var myObjects = new Dictionary<string, Object>();
    foreach (var pair in myObjectToBeCreated)
    {
        var strNamespace = //set namespace of 'pair.Key'
        myObjects.Add(pair.Value, Activator.CreateInstance(strNamespace, pair.Key));
    }
    // and using it
    var myEmployeeObject = (Employee)myObjects["myEmployeeObject"];
