    public class ParallelReadExample
    {
        public static IEnumerable LineGenerator(StreamReader sr)
        {
            while ((line = sr.ReadLine()) != null)
            {
                yield return line;
            }
        }
    
        static void Main()
        {
            // Display powers of 2 up to the exponent 8:
    		StreamReader sr = new StreamReader("yourfile.txt")
    		
    		Parallel.ForEach(LineGenerator(sr), currentLine =>
                {
    				// Do your thing with currentLine here...
                } //close lambda expression
            );
    		
    		sr.Close();
        }
    }
