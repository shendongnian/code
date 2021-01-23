    using System;
    using System.Reflection;
    using ClassLibrary;
    namespace Demo
    {
        internal class Program
        {
            private static void Main(string[] args)
            {
                var test = new TargetContainerDto();
                setType(test, 1);
                test.Print();
            }
            public static void setType(TargetContainerDto t, int val)
            {
                BindingFlags bf = BindingFlags.NonPublic | BindingFlags.Instance;
                PropertyInfo pi = t.GetType().GetProperty("Type", bf);
                pi.SetValue(t, val, null);
            }
        }
    }
