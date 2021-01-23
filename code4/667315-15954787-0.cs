    public void ComputeRetirementBenefitCost(Employee.EmpType e, out int benefitCost)
    {   
        switch (e)
        {
           case Employee.EmpType.President:
               benefitCost = 100000;
               break;
           case Employee.EmpType.Manager:
               benefitCost = 5000;
               break;
           case Employee.EmpType.Janitor:
               benefitCost = 1000;
               break; 
           default:
               throw new ArgumentOutOfRangeException("e");
        }
    }
