    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Runtime.InteropServices;
    namespace InterceptorTest
    {
        public class Interceptor : IDisposable
        {
            #region DllImports
            
            [DllImport("interception.dll", CharSet = CharSet.Auto, SetLastError = true)]
            public static extern IntPtr interception_create_context();
            
            [DllImport("interception.dll", CharSet = CharSet.Auto, SetLastError = true)]
            public static extern void interception_destroy_context(IntPtr context);
            
            [DllImport("interception.dll", CharSet = CharSet.Auto, SetLastError = true)]
            public static extern void interception_set_filter(IntPtr context, InterceptionPredicate predicate, ushort filter);
            
            // The function pointer type as defined in interception.h that needs to be defined as a delegate here
            public delegate int InterceptionPredicate(int device);
            
            #endregion
                    
            #region private members
            
            private InterceptionPredicate m_PredicateDelegate { get; set; }
            private IntPtr m_Context { get; set; }
            
            #endregion
            
            #region methods
            
            public Interceptor(ushort filter)
            {
                // be sure to initialize the context
                this.m_PredicateDelegate = new InterceptionPredicate(this.DoSomethingWithInterceptionPredicate);
                this.m_Context = interception_create_context();
                interception_set_filter(this.m_Context, this.m_PredicateDelegate, filter);
            }
            private void Cleanup()
            {
                interception_destroy_context(this.m_Context);
                // the next line is not really needed but since we are dealing with
                // managed to unmanaged code it's typically best to set to 0
                this.m_Context = IntPtr.Zero;
            }
            
            public void Dispose()
            {
                this.Cleanup();
                GC.SuppressFinalize(this);
            }
            
            protected virtual void Dispose(bool disposing)
            {
                if (disposing) { this.Cleanup(); }
            }
            
            public int DoSomethingWithInterceptionPredicate(int device)
            {
                // this function is something you would define that would do something with
                // the device code (or whatever other paramaters your 'DllImport' function might have
                // and return whatever interception_set_filter is expecting
                return device;
            }
            
            #endregion
        }
        
        static class Program
        {
            [STAThread]
            private static void Main(string[] argv)
            {
                Interceptor icp = new Interceptor(10);
                // do something with the Interceptor object
            }
        }
    }
