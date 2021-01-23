    // Via a public method
    public class Foo : IDisposable
    {
        public void Dispose()
        {
            // Stuff
        }
    }
    // Via explicit interface implementation
    public class Bar : IDisposable
    {
        void IDisposable.Dispose()
        {
            // Stuff
        }
    }
