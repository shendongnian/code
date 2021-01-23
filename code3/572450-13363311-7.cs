        class Dependent : IDisposable
        {
            // ...
            public void Dispose()
            {
                Program.SomethingHappened -= Program_SomethingHappened;
                
                _resource = null;
            }
        }
