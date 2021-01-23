    public class Program
    {
        private static FileStream streamToLogFile = new FileStream(...);
        public int Main(string [] args)
        {
             new Run(new Form1(streamToLogFile));
         }
    }
