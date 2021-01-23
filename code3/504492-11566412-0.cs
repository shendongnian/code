    // Only members of the CalculatorClients group can call this method.
    [PrincipalPermission(SecurityAction.Demand, Role = "CalculatorClients")]
    public double Add(double a, double b)
    {
      return a + b;
    }
