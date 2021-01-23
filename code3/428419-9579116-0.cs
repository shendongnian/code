        class Program
    	{
    		static void Main(string[] args)
    		{
    			double[] Array = new double[] { 10.1, 20.2, 30.0, 40.0 };
    			Console.Write("Original:\t");
    			PrintArray(Array);
    
    			byte[] byteArray = GetBytesAlt(Array);
    			double[] doubleArray = GetDoublesAlt(byteArray);
    			Console.Write("Round-trip:\t");
    			PrintArray(doubleArray);
    
    			Console.ReadLine();
    		}
    
    		static void PrintArray(Double[] array)
    		{
    			for (int i = 0; i < array.Length; i++)
    			{
    				Console.Write(array[i]);
    				Console.Write(",");
    			}
    			Console.WriteLine();
    		}
               
                // rest of methods are same
                ...
         }
