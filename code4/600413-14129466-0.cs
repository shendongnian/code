    // Define other methods and classes here
    class Foo<T>
    {
        public List<T> Items { get; set; }
    }
    class Program
    {
		void Main()
		{	
			//just to demonstrate where this comes from
			Foo<int> fooObject = new Foo<int>();
			fooObject.Items = new List<int> { 1, 2, 3};
			object obj = (object)fooObject;
			
			//now trying to get the Item value back from obj
			//assume I have no idea what <T> is
			PropertyInfo propInfo = obj.GetType().GetProperty("Items"); //this returns null
			object itemValue = propInfo.GetValue(obj, null);
			
			Console.WriteLine(itemValue);
                        // Does not print out NULL - prints out System.Collections.Generic.List`1[System.Int32]
		    
		    IList values = (IList)itemValue;
		    foreach(var val in values)
		        Console.WriteLine(val); // Writes out values appropriately
		}
    }
