    public double GetVariableValue(string varName)
    {
        double val;
        if (!variables.TryGetValue(varName, out val))
           throw new InvalidOperationException("Undefined variable "+varName);
        return val;
    }
