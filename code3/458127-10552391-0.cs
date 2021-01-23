    //...
    var index = 0;
    foreach (PropertyInfo t in properties)
    {
        var propName = t.Name;
        int index1 = index; // avoid access to modified closure
        moq.Setup(x => x.GetFieldType(index1)).Returns(t.PropertyType);
        moq.Setup(x => x.GetName(index1)).Returns(propName);
        moq.Setup(x => x[index1])
            .Returns(ojectsToEmulate[count]
                     .GetType()
                     .GetProperty(propName).GetValue(ojectsToEmulate[count], null));
        index++;
    }
    moq.Setup(x => x.FieldCount).Returns(properties.Length);
    //...
