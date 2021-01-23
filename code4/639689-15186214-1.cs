    dynamic instance = Activator.CreateInstance(tableType);
    var tableInterface = tableType.GetInterfaces().FirstOrDefault(it => it.IsGenericType && it.GetGenericTypeDefinition() == typeof(ITable<>));
    if(tableInterface == null) throw new ArgumentException("Type is not a table type");
    var rowType = tableInterface.GetGenericArguments()[0];
    var newRow = Activator.CreateInstance(rowType);
    return (int)instance.Insert(newRow);
