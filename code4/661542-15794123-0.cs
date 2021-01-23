    public class Program
    {
        static void Main(string[] args)
        {
            double[] values = { 0.0, 1.0, 2.0 };
            using (StreamWriter writer = new StreamWriter(@"C:\out.txt"))
            {
                foreach (var value in values)
                {
                    writer.WriteLine(value);
                }
            }
        }
    }
