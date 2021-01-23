    void Main()
    {
        var records = new List<dynamic>{
		   new { Id = 1, Name = "one" },
		   new { Id = 2, Name = "two" },
    	};
	
	    Console.WriteLine(records.ToCsv());
    }
    public static class Extensions {
	    public static string ToCsv<T>(this IEnumerable<T> collection)
    	{
	    	using (var memoryStream = new MemoryStream())
		    {
			    using (var streamWriter = new StreamWriter(memoryStream))
    			using (var csvWriter = new CsvWriter(streamWriter))
	    		{
		    		csvWriter.WriteRecords(collection);
			    } // StreamWriter gets flushed here.
    			return Encoding.ASCII.GetString(memoryStream.ToArray());
	    	}
    	}
    }
