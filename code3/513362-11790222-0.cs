    static void Main(string[] args)
        {
            // StreamReader is IDisposable which should be wrapped in a using statement
            using (StreamReader sStreamReader = new StreamReader("d:\\TEST.txt")) {
	            while (!sStreamReader.EndOfStream)
	            {
	                string sLine = sStreamReader.ReadLine();
	                // make sure we have something to work with
	                if (String.IsNullOrEmpty(sLine)) continue;
	                string[] cols = sLine.Split(',');
	                // make sure we have the minimum number of columns to process
	                if (cols.Length > 4) {
	                   double a = Convert.ToDouble(cols[1]);
	                   Console.Write(a);
	                   int b = Convert.ToInt32(cols[3]);
	                   Console.WriteLine(b);
	                   Console.WriteLine();
	                }
	            }
		}
        }
