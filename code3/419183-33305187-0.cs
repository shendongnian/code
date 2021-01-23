    class Program
    {
        static void Main(string[] args)
        {
            object obj = DBNull.Value;
            if(obj != DBNull.Value) {
                double d = Convert.ToDouble(obj);
                Console.WriteLine(d.ToString());
            }
        }
    }
