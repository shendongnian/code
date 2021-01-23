    foreach (var elem in myDict) // var is KeyValuePair<myObject, Dictionary<myEnum, secondObject>>
    {
        var innerDict = elem.Value; // Value is Dictionary<myEnum, secondObject>
        if (innerDict != null)
        {
            if (innerDict.ContainsKey(enumVal)) // key is myEnum
            {
                var value = innerDict[enumVal]; // var is secondObject
            }
        }
    }
