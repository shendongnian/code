    class Program
    {
        static void Main(string[] args)
        {
    
            DateTime myDate = DateTime.Now;
    
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(myDate.AddDays(-i).ToString("MM-dd-yyyy"));
            }
    
    
        }
    }
