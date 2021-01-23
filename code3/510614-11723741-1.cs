    public class B 
    {
        public int A1 { get; private set; }
        public int A2 { get; private set; }
        public B(int new_args1, int new_args2)
        {
            // new_args1 has the value 42
            A1 = new_args1;
            // new_args2 has the value 24
            A2 = new_args2;
        }
    }
