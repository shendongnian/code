    dynamic instance = Activator.CreateInstance(tableType);
    var tableInterface = tableType.GetInterfaces().First(it => it.IsGenericType && it.GetGenericTypeDefinition() == typeof(ITable<>))
    var rowType = tableInterface.GetGenericArguments()[0];
    
    var newRow = Activator.CreateInstance(rowType);
    return (int)instance.Insert(newRow);
