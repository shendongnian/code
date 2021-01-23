    using System;
    namespace Test
    {
        class Program
        {
            static void Main(string[] args)
            {
                var lifeCycle = (LifeCycle)1;
                Console.WriteLine(lifeCycle);
                //Output: Approved
            }
        }
        public enum LifeCycle
        {
            Pending = 0,
            Approved = 1,
            Rejected = 2,
        }
    }
