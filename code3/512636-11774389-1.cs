	static void Main()
	{
	   var arrays = Split(new[]{1,2,3,4,5,6,7,8,9,0}, 3);
	   
	   foreach(var array in arrays)
	   {
	   		foreach(var item in array)
				Console.WriteLine(item);
			Console.WriteLine("---------------");
	   }
	}
