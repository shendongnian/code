    public class MyClass : IDisposable
    {
        public void Dispose()
        {
            // Perform any object clean up here.
    
            // If you are inheriting from another class that
            // also implements IDisposable, don't forget to
            // call base.Dispose() as well.
        }
    }
