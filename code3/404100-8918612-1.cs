    bool ValidateExpression(string expression)
    {
        string[] parts = expression.Split("/");
    
        if (
            parts.Length != 2
            || parts[0].Length != 3
            || parts[1].Length != 4
        ) return false;
        
        int parsed;
        return Int32.TryParse(parts[0], out parsed) && Int32.TryParse(parts[1], out parsed);    
    }
