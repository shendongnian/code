	class Program
    {
        static void Main(string[] args)
        {
            var myDemo = new Demo();
            myDemo.Size = 1000000;
			myDemo.Value = 15.7m;
    
            Console.WriteLine("ToSizeInKb: " + myDemo.ToString(DemoConversionType.ToSizeInKb));
			Console.WriteLine("ToValue: " + myDemo.ToString(DemoConversionType.ToValue));
			Console.WriteLine(Environment.NewLine + "Press enter to exit.");
            Console.ReadKey();
        }
    
		/// <summary>
		/// Defines different ways to convert the Demo class objects into strings.
		/// </summary>
        enum DemoConversionType
        {
            ToSizeInKb,
			ToValue
        }
    
        class Demo
        {
            public int? Size { get; set; }
            public decimal Value { get; set; }
    
			/// <summary>
			/// Override the default ToString method and pass a "DemoConversionType"
			/// that defaults how the object should be converted to a string.
			/// </summary>
			/// <returns></returns>
			/// <param name='convType'></param>
            public string ToString(DemoConversionType convType)
            {
                switch (convType)
                {
					// Return the Size in Kb
                    case DemoConversionType.ToSizeInKb:
                        return Size.GetValueOrDefault() / 1000 + "Kb";
					// Return the Value to 2 decimal places.
				    case DemoConversionType.ToValue:
					    return string.Format("{0:N2}", Value);
					// Bad conv type, default back to the base ToString() method.
                    default:
                        return base.ToString();
                }
            }
        }
    }
