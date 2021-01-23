    public static void RunSnippet()
    	{
    		
    		Console.WriteLine(myCustomFormatter(3.42421));
    		Console.WriteLine(myCustomFormatter(265.6250));
    		Console.WriteLine(myCustomFormatter(812.50));
    		Console.WriteLine(myCustomFormatter(12.68798));
    		Console.WriteLine(myCustomFormatter(0.68787));
    		Console.ReadLine();
    			
    	}
    	
    	public static double myCustomFormatter(double value)
    	{
    		string sValue = value.ToString();
    		string sFormattedValue = sValue.Substring(0,5);
    		double dFormattedValue= Convert.ToDouble(sFormattedValue);
    		return dFormattedValue;
    	}
