    public class Program
    {
        public static void Main()
        {
            foreach (FieldInfo fInfo in typeof(Evaluation).GetFields(BindingFlags.Public | BindingFlags.Static))
            {
                Console.WriteLine("Evaluation." + fInfo.Name);
            }
            Console.ReadLine();
        }
    }
