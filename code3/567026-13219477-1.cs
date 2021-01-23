    public class Program
    {
        int i; //this was not explicitly initialized
        public Program()
        {
            int j; //need to initialize this before use
            Console.Write(j);  //this throws "Use of unassigned variable" error
            Console.Write(i);  //this prints 0, the default value
        }
    }
