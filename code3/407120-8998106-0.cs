    using System;
    namespace SomeNamespace
    {
        public interface IInterface
        {
            void Print(string format, params object[] args);
        }
        public class Implementation : IInterface
        {
            public void Print(string format, params object[] args)
            {
                Console.WriteLine(format, args);
            }
        }
    }
