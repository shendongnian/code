    internal class Program
        {
            private static void Main(string[] args)
            {
                IntWrapper a = 4;
    
                var list = new List<IntWrapper>();
    
                list.Add(a);
    
                a.Value = 5;
                //a = 5; //Dont do this. This will assign a new reference to a. Hence changes will not reflect inside list.
    
                foreach (var v in list)
                    Console.WriteLine("a=" + v);
            }
        }
    
        public class IntWrapper
        {
            public int Value;
    
            public IntWrapper()
            {
                
            }
    
            public IntWrapper(int value)
            {
                Value = value;
            }
    
            // User-defined conversion from IntWrapper to int
            public static implicit operator int(IntWrapper d)
            {
                return d.Value;
            }
            //  User-defined conversion from int to IntWrapper
            public static implicit operator IntWrapper(int d)
            {
                return new IntWrapper(d);
            }
    
            public override string ToString()
            {
                return Value.ToString();
            }
        }
