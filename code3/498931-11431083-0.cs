    public class YourClass{
        
        private static readonly int g_RandomInt;
        
        static YourClass(){
            g_RandomInt = new Random().Next();    
        }
        
        public void InstanceMethod()
        {
            Console.WriteLine(g_RandomInt);
        }
    }
