    using System;
    using System.Diagnostics;
    internal class Program
    {
        private static event Action A;
        private static void Method1() {}
        private static void Method2() {}
        private static void Method3() {}
        private static void Main()
        {
            A += Method1;
            A += Method2;
            A += Method3;
            var totalMemory = GC.GetTotalMemory(true);
            while(true)
            {
                A();
                // Uncommenting the line below will cause the Debug.Assert to be hit.
                // var a = new int[] {};
                if (totalMemory != GC.GetTotalMemory(false))
                {
                    // Does not get hit unless line above allocating an array is
                    // uncommented.
                    Debug.Assert(false);
                }
            }
        }
    }
