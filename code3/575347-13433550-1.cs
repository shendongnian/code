    class YourTypeName
	{
		public YourTypeName(int MinValue,  int MaxValue)
		{  
			this.Min=MinValue;
			this.Max=MaxValue;
		}
		
		public int Min {get;set;}
		
		public int Max {get;set;}
	}
	var a = new YourTypeName { Min = 20 };
	var b = new YourTypeName { Max = 20 };
