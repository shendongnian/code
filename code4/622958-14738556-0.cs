    Type paramType = method.Item4[comboBox2.SelectedIndex - 1].ParameterType;
    if(paramType.HasElementType)
    {
        paramType = paramType.GetElementType();
    }
    
    if(Nullable.GetUnderlyingType(paramType) != null)
    {
    }
