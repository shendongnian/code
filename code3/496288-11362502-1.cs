        public class SomethingVeryLongLived : IDisposable
        {
            …
        }
        …
        public static void Main()
        {
            using (var sth = new SomethingVeryLongLived(…))
            {
                Application.Run(new SomeForm(…));
            } // <-- at this point, foo.Dispose() is guaranteed to be called.
        }
