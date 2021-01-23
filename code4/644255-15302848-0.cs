    public class ClosureClass
    {
        public int i;
        public void DoStuff()
        {
            Console.WriteLine(i);
        }
    }
    class Program
    {
        delegate void Writer();
        static void Main(string[] args)
        {
            var writers = new List<Writer>();
            ClosureClass closure = new ClosureClass();
            for (closure.i = 0; closure.i < 10; closure.i++)
            {
                writers.Add(closure.DoStuff);
            }
            foreach (Writer writer in writers)
            {
                writer();
            }
        }
    }
