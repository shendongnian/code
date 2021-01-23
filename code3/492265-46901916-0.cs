    var parameters = new List<string>();
    
    foreach (var method in methods)
    {
       foreach (var n in method.ParameterList.Parameters)
       {
         var parameterName = n.Identifier.Text;
         parameters.Add(parameterName);
       }
    }
