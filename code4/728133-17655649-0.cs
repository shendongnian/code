    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int x = Convert.ToInt32(Console.ReadLine());
                if (x >= 5 && x <= 9)
                {
                    CustomException e = new CustomException("Please Eneter Another Number");
                    throw e;
                }
            }
            catch (CustomException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
    public class CustomException : System.Exception
    {
        public CustomException(string txt)
            : base(txt)
        {
        }
    }
