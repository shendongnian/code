    public class Class1
    {
        public int A { get; }
        public Class1(int a)
        {
            A = a;
        }
        public void Mutate()
        {
            // Class1.cs(11,9,11,10): error CS0200: Property or indexer 'Class1.A' cannot be assigned to -- it is read only
            A++;
        }
    }
