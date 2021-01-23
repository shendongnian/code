    Regex modelExpression = new Regex("^([A-Za-z]+)([0-9]+)([A-Za-z]+)$");
    
    // Inside for loop...
    Match m = modelExpression.Match(product.ModelName);
    if (m.Success)
    {
        product.ModelName = m.Groups[1].Value.ToUpper() 
             + m.Groups[2].Value 
             + m.Groups[3].Value.ToLower();
    }
