	class Program
	{
		static void Main(string[] args)
		{
			var parameters = new List<MyParam> { 
				new MyParam { Name="bla", Size=1 }, 
				new MyParam { Name="lala", Size=10 }, 
			};
			var xml = new XElement("Parameters",
				from p in parameters
				select new XElement("Parameter",
					 new XAttribute("Name", p.Name),
					 ConditionalElement(p)
					)
			);
		}
		private static XElement ConditionalElement(MyParam arg)
		{
			if (arg.Size < 5)
			{
				return new XElement("Type", "Small");
			}
			else
			{
				return new XElement("Type", "Big");
			}
		}
	}
	class MyParam
	{
		public int Size { get; set; }
		public string Name { get; set; }
	}
