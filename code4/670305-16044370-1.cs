    public class Class1
    {
        public int c = 0;
        public void add(int a, int b)
        {
            c = a + b;
            if (Added != null)
                Added(this, /*new AddArgs(c)*/ c); // Don't use AddArgs
        }
        //public delegate void AddHandler(object sender, AddArgs e); // Don't use AddHandler
        public event /*AddHandler*/ EventHandler<int> Added; // Change this to EventHandler<int>
    }
