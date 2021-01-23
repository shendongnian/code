    public enum YesNo
    {
        Yes,
        No,
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            YesNo? value = null;
            switch (value)
            {
                case YesNo.Yes:
                    Console.WriteLine("Yes");
                    break;
                case YesNo.No:
                    Console.WriteLine("No");
                    break;
                default:
                    Console.WriteLine("default");
                    break;
            }
        }
    }
