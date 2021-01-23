    using System;
    using System.Reflection;
    using System.Runtime.InteropServices;
    
    public class ComRef<T> : IDisposable where T : class
    {
        private T reference;
        
        public T Reference
        {
            get
            {
                return reference;
            }
        }
        
        public ComRef(T o)
        {
            reference = o;
        }
        
        public void Dispose()
        {
            if (reference != null)
            {
                Marshal.ReleaseComObject(reference);
                reference = null;
            }
        }
    }
    
    public class Test
    {
        static void Main()
        {
            Type excelAppType = Type.GetTypeFromProgID("Excel.Application");
            using (var comRef = new ComRef<object>(Activator.CreateInstance(excelAppType)))
            {
                var excel = comRef.Reference;
                // ...
    	        excel.GetType().InvokeMember("Quit", BindingFlags.InvokeMethod, null, excel, null);
            }
        }
    }
