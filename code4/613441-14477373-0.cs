	internal class Csv
	{
		public string CommaSepList { get; set; }
	}
    var allCsvs =
    	new List<Csv>
    		{
    			new Csv
    				{
    					CommaSepList = "1,2,3,4,,5"
    				},
    			new Csv
    				{
    					CommaSepList = "4,5,7,,5,,"
    				},
    		};
    int[] intArray =
    	allCsvs
    		.Select(c => c.CommaSepList)
    		.SelectMany(s => s.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries))
    		.Select(int.Parse)
    		.ToArray();
