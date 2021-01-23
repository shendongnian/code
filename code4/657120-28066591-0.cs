    Expression e = new Expression("DayDiff(#16/02/2013#, #15/02/2013#)");
	e.EvaluateFunction += delegate(string name, FunctionArgs args)
	{
		if (name == "DayDiff")
		{
			var date1 = args.Parameters[0].Evaluate();
			var date2 = args.Parameters[1].Evaluate();
    		var timespan = date2 - date1;
    		return timespan.TotalDays; // double (you can convert to int if you wish a whole number!)
		}
    }
    Console.Write(e.Evaluate());
