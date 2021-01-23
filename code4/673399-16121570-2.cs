    string _strDecimal = "3.5";
    decimal _dec;
    bool _valid = Decimal.TryParse(_strDecimal, out _dec);
    if (_valid)
    (
    	if ((_dec >= 0) && (_dec <= 5))
    	{
    		Console.WriteLine("Valid");
    	}
    	else
    	{
    		Console.WriteLine("Invalid");
    	}
    )
    esle
    {
    		Console.WriteLine("Invalid");
    }
