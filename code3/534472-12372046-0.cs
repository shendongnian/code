    public class Example
    {
        static void Main(string[] args)
        {
            VersionControlServer vcs = ConnectToServer(); // ... etc ...
            vcs.NonFatalError += Example.OnNonFatalError;
        }
        internal static void OnNonFatalError(Object sender, ExceptionEventArgs e)
        {
            if (e.Exception != null)
            {
                Console.Error.WriteLine("  Non-fatal exception: " + e.Exception.Message);
            }
            else
            {
                Console.Error.WriteLine("  Non-fatal failure: " + e.Failure.Message);
            }
        }
    }
