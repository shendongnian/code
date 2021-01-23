    public class myObject
	{
		public string Name {get;set;}
		public double Value {get;set;}
	}
	
	var testData = new List<myObject>() { 
										new myObject() { Name = "item1", Value = 20 },
										new myObject() { Name = "item2", Value = 30 },
										new myObject() { Name = "item1", Value = 50 }
										};
	
	var result = from x in testData
				 group x by x.Name into grp
				 select new myObject() { 
				 						Name=grp.Key,
										Value= grp.Average(obj => obj.Value)
										};
