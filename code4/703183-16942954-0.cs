    [PrincipalPermission(SecurityAction.Demand, Role = "CalculatorClients")]
    public double Add(double a, double b)
    {
        return a + b;
    }
