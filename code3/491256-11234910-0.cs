    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    
    class Program
    {
        public static void Main()
        {
            Action x = null;
            x += () => Console.WriteLine("First");
            x += () => { throw new Exception("Bang 1"); };
            x += () => { throw new Exception("Bang 2"); };
            x += () => Console.WriteLine("Second");
            
            try
            {
                ExecuteAll<Action>(x, action => action());
            }
            catch (AggregateException e)
            {
                Console.WriteLine(e);
            }
        }
        
        public static void ExecuteAll<T>(Delegate multi, Action<T> invoker)
        {
            List<Exception> exceptions = new List<Exception>();
            foreach (var single in multi.GetInvocationList())
            {
                try
                {
                    invoker((T)(object)single);
                }
                catch (Exception e)
                {
                    exceptions.Add(e);
                }
            }
            if (exceptions.Count > 0)
            {
                throw new AggregateException(exceptions);
            }
        }
    }
