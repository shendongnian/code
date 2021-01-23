    class Program
    {
        static void Main(string[] args)
        {
            Operators ops = new Operators();
            object result = ops.Use("LessOrEqual", new object[] {3,2}); // output: False
            Console.WriteLine(result.ToString());
            
            result =  ops.Use("Increment", new object[] {3}); // output: 4
            Console.WriteLine(result.ToString());
            Console.ReadKey();
        }
    }
    public class Operators
    {
        public object Use(String methodName, Object[] parameters)
        {
            object result;
            MethodInfo mInfo = this.GetType().GetMethod(methodName);
            result = mInfo.Invoke(this, parameters); // params for operator, komma-divided
            return result;
        }
        
        
        public bool LessOrEqual(int a, int b)
        {
            if (a <= b)
            {
                return true;
            }
            else
            {
                return false; 
            }  
        }
        public int Increment(int a)
        {
            return ++a;
        }
    }
