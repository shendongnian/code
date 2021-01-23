    // Note that this has been shortened.  The compiler will take care of making a backing field for us; we don't need to worry about it.
    public double Salary { get; set; }
    
    public Employee()
    {
        // Only set the default value for Salary in the parameterless constructor.
    	Salary = 20000.0;
    }
    
    public Employee(double salary)
    {
        // Notice how the parameter names are more verbose.
    	Salary = salary;
    }
    
    public void SetSalary(string value)
    {
    	double salary;
    	// TryParse allows us to handle errors manually, rather than dealing with (slow) exceptions.
    	if (double.TryParse(value, out salary))
    	{
    		Salary = salary;
    	}
    	else
    	{
    		// We should really do something other than just throw an exception here, but that's what I'm doing for example purposes.
    		throw new ArgumentException("Argument must be parsable as a double.", "value");
    	}
    }
