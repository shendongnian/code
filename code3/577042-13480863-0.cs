    foreach (var t in typeof (A).GetNestedTypes(BindingFlags.Public | BindingFlags.NonPublic))
        Console.WriteLine(t.FullName);
    class A
    {
        private class B
        {
        }
        protected class C
        {
        }
        internal class D
        {
        }
        public class E
        {
            
        }
    }
