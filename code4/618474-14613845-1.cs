    using System;
    
    public class Test
    {
        public void CheckThisForNullity()
        {
            Console.WriteLine("Is this null? {0}", this == null);
        }
        
        static void Main(string[] args)
        {
            var method = typeof(Test).GetMethod("CheckThisForNullity");
            var openDelegate = (Action<Test>) Delegate.CreateDelegate(
                   typeof(Action<Test>), method);
            openDelegate(null);
        }
    }
