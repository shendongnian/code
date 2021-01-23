    // Executed code
    var filteredList = listWithNames.Where(GetLambdaExpression("Adam"));
    
    // method
    public Func<bool, ListElementTypeName> GetLambdaExpression(string name)
    {
        return listElement => listElement.Name == name;
    }
