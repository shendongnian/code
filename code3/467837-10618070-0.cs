    public class MainClass
    {
    	enum SignEnum { signed, unsigned, notAvail }
    	class Element
    	{
    		public string Company;
    		public SignEnum Signed;
    		public string TypeOfInvestment;
    		public decimal Worth;
    	}
    	class GroupedResult
    	{
    		public string TypeOfInvestment;
    		public decimal signed, unsigned, notAvailable;
    		public decimal Sum;
    	}
    	public static void Main()
    	{
    		List<Element> elements = new List<Element>()
    		{
    			new Element { Company = "JPMORGAN CHASE", Signed = SignEnum.signed,
    				TypeOfInvestment = "Stocks", Worth = 96983 },
    			new Element { Company = "AMER TOWER CORP", Signed = SignEnum.unsigned,
    				TypeOfInvestment = "Securities", Worth = 17141 },
    			new Element { Company = "ORACLE CORP", Signed = SignEnum.unsigned,
    				TypeOfInvestment = "Assets", Worth = 59372 },
    			new Element { Company = "PEPSICO INC", Signed = SignEnum.notAvail,
    				TypeOfInvestment = "Assets", Worth = 26516 },
    			new Element { Company = "PROCTER & GAMBL", Signed = SignEnum.signed,
    				TypeOfInvestment = "Stocks", Worth = 387050 },
    			new Element { Company = "QUASLCOMM INC", Signed = SignEnum.unsigned,
    				TypeOfInvestment = "Bonds", Worth = 196811 },
    			new Element { Company = "UTD TECHS CORP", Signed = SignEnum.signed,
    				TypeOfInvestment = "Bonds", Worth = 257429 },
    			new Element { Company = "WELLS FARGO-NEW", Signed = SignEnum.unsigned,
    				TypeOfInvestment = "Bank Account", Worth = 106600 },
    			new Element { Company = "FEDEX CORP", Signed = SignEnum.notAvail,
    				TypeOfInvestment = "Stocks", Worth = 103955 },
    			new Element { Company = "CVS CAREMARK CP", Signed = SignEnum.notAvail,
    				TypeOfInvestment = "Securities", Worth = 171048 },
    		};
    
    		string header = "Company".PadLeft(15) + " " +
    			"Signed".PadLeft(10) + " " +
    			"Type Of Investment".PadLeft(20) + " " +
    			"Worth".PadLeft(10);
    		Console.WriteLine(header);
    		Console.WriteLine(new string('-', header.Length));
    		foreach (var e in elements)
    		{
    			Console.WriteLine(e.Company.PadLeft(15) + " " +
    				e.Signed.ToString().PadLeft(10) + " " +
    				e.TypeOfInvestment.PadLeft(20) + " " +
    				e.Worth.ToString().PadLeft(10));
    		}
    
    		Console.WriteLine();
    
    		var query = from e in elements
    														group e by e.TypeOfInvestment into eg
    														select new GroupedResult
    														{
    															TypeOfInvestment = eg.Key,
    															signed = eg.Where(x => x.Signed == SignEnum.signed).Sum(y => y.Worth),
    															unsigned = eg.Where(x => x.Signed == SignEnum.unsigned).Sum(y => y.Worth),
    															notAvailable = eg.Where(x => x.Signed == SignEnum.notAvail).Sum(y => y.Worth),
    															Sum = eg.Sum(y => y.Worth)
    														};
    
    		string header2 = "Type of investment".PadRight(20) + " " +
    			"signed".PadLeft(8) + " " +
    			"unsigned".PadLeft(8) + " " +
    			"notAvailable".PadLeft(13) + " " +
    			"Sum";
    		Console.WriteLine(header2);
    		Console.WriteLine(new string('-', header2.Length));
    		foreach (var item in query)
    		{
    			Console.WriteLine(item.TypeOfInvestment.PadRight(20) + " " +
    				item.signed.ToString().PadLeft(8) + " " + 
    				item.unsigned.ToString().PadLeft(8) + " " +
    				item.notAvailable.ToString().PadLeft(13) + " " +
    				item.Sum.ToString()
    				);
    		}
    	}
    }
