    using System;
    
    class Program
    {
        private static void Main()
        {
            var outer = new Outer();
            Console.WriteLine(outer.GetValue() == null);
        }
    }
    
    class Outer
    {
        private Inner m_inner = new Inner();
    
        public object GetValue()
        {
            return m_inner.GetValue();
        }
    
        ~Outer()
        {
            m_inner.Dispose();
        }
    }
    
    class Inner
    {
        private object m_value = new object();
    
        public object GetValue()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            return m_value;
        }
    
        public void Dispose()
        {
            m_value = null;
        }
    }
