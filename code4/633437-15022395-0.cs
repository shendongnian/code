    class Temp
	{
		public static object Convert<T1, T2>()
		{ 
		    //do stuff        
		}
	}
    var method =  typeof(Temp).GetMethod("Convert")
                                 .MakeGenericMethod(typeof (Test), typeof (Test));
    method.Invoke(null, null);  //assume Convert is static method
