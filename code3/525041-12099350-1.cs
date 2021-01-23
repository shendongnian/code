    class Program
    {
        WrappedField<int> _weight = new WrappedField<int>(
            i => i.Value,           // get
            (i, v) => i.Value = v,  // set
            11);                    // initialValue
    
        static void Main(string[] args)
        {
            Program p = new Program();
            p._weight.Value = 10;
    
            Console.WriteLine(p._weight.Value);
        }
    }
