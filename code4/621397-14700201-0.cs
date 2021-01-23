    public class MYclass
        {
            public int Id { get; set; }
        }
    
    
    class Program
    {
        static void Main(string[] args)
        {
            Object obj = new MYclass();
            MYclass mc = new MYclass();
    
            Console.WriteLine(obj.GetType());
            MYclass mc2 = obj as MYclass;
            Console.WriteLine(mc2.Id);
            Console.WriteLine(mc.Id);
    
            Console.ReadLine();
        }
    }
