    using System;
    using System.Collections.Generic;
    using System.Linq;
    using LINQtoCSV;
    namespace LinqCsvSandbox
    {
	class SampleData
	{
		[CsvColumn(Name = "ID", FieldIndex = 1)]
		public string ID { get; set; }
		[CsvColumn(Name = "PersonName", FieldIndex = 2)]
		public string Name { get; set; }
		public override string ToString()
		{
			return string.Format("{0}: {1}", ID, Name);
		}
	}
	class Program
	{
		static void Main(string[] args)
		{			
			var inputFileDescription = new CsvFileDescription
			{
				SeparatorChar = ',', 
				FirstLineHasColumnNames = false,
				FileCultureName = "en-us",
 				EnforceCsvColumnAttribute = true,
			};
			CsvContext cc = new CsvContext();
			IEnumerable<SampleData> data1 = cc.Read<SampleData>("File1.csv", inputFileDescription);
			IEnumerable<SampleData> data2 = cc.Read<SampleData>("File2.csv", inputFileDescription);
			IEnumerable<SampleData> all = data1.Concat(data2);
			// Uncomment to see the items printed
			//foreach(var item in all)
			//	Console.WriteLine(item);
                        
			cc.Write(all, "All.csv");			
		}
	}
    }
