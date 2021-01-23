	class Program
	{
		static void Main(string[] args)
		{
			int sizeOf = 3; //size of problem - ex 3x3
			var vals = "abcdefghijklmnop".ToCharArray(); //up to 16 (abc in ex)
			//Create initial problem
			String[] x = new String[sizeOf]; 
			String[] y = new String[sizeOf];
            for (int i = 0; i < x.Length; i++)
            {
				x[i] = vals[i].ToString();
				y[i] = vals[i].ToString();
            }
			//hold our solutions
			String[][] result = null;
			String[] temp = x;
			for (int i = 1; i < y.Length; i++)
			{
				result = getCombos(temp, y);
				temp = (from k in result
						from l in k
						select l).ToArray();
			}
			
			//Flatten out solution
			var finalResult = (from k in result
							   from l in k
						       select l).ToList();
			printArray(finalResult);
			Console.WriteLine("Total Count: {0}", finalResult.Count());
           
        }
		static void printArray(List<String> a)
		{
			foreach (var x in a)
			{
				Console.Write("{0} ", x);
			}
			Console.WriteLine();
		}
		static String[][] getCombos(String[] x, String[] y)
		{
			//Initialize array to hold solution
			String[][] prefixes = new String[x.Length][];
			for (int j = 0; j < x.Length; j++)
			{
				prefixes[j] = new String[y.Length];
			}
			//concat to form solution
			for (var i = 0; i < x.Length; i++)
			{
				for (var j = 0; j < y.Length; j++)
				{
					prefixes[i][j] = x[i] + y[j];
				}
			}
			return prefixes;
		}
	}
