    protected string RenderSalaryType(object oItem)
    {
    	int salaryType = (int)DataBinder.Eval(oItem, "SalaryType");
    	string salaryFrom = (int)DataBinder.Eval(oItem, "SalaryFrom").ToString();
    	string salaryTo = (int)DataBinder.Eval(oItem, "SalaryTo").ToString();
    	
    	// rest of your code
    }
