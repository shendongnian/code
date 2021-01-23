    static void Main(string[] args)
        {
            // StreamReader is IDisposable which should be wrapped in a using statement
            using (StreamReader reader = new StreamReader(@"d:\TEST.txt")) 
            {
	            while (!reader.EndOfStream)
	            {
	                string line = reader.ReadLine();
	                // make sure we have something to work with
	                if (String.IsNullOrEmpty(line)) continue;
	                string[] cols = line.Split(',');
	                // make sure we have the minimum number of columns to process
	                if (cols.Length < 4) continue;
                    double a = Convert.ToDouble(cols[1]);
                    Console.Write(a);
                    int b = Convert.ToInt32(cols[3]);
                    Console.WriteLine(b);
                    Console.WriteLine();
	            }
            }
        }
