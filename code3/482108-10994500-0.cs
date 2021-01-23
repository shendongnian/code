    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var temp = @"C:\\Program Files\\my path\\";
                string filePath = Path.Combine(temp, "fileName.txt");
                StreamWriter sw = File.CreateText(filePath);
                Console.WriteLine("I got here");
            }
            catch (Exception)
            {
                Console.WriteLine("I didn't");
                //
            }
        }
    }
