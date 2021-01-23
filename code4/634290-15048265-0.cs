    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                Main m = new Main();
                m.Test();
            }
            catch (Exception e)
            {
                Console.Write("Uh oh :O " + e.Message);
            }
        }
    }
