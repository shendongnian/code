    public enum YesNo
    {
        Yes,
        No,
        FileNotFound,
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            YesNo? value = YesNo.FileNotFound;
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
