        static void Main(string[] args)
        {
            Trace.Listeners.Add(new ConsoleTraceListener());
            AppDomain.CurrentDomain.UnhandledException += OnNoes;
            try
            {
                // INSERT BURN STATEMENT
                Foo();
            }
            catch (Exception e)
            {
                Bar();
            }
            finally
            {
                Baz();
            }
        }
        static void Foo()
        {
            Trace.WriteLine("I AM FOO!");
        }
        static void Bar()
        {
            Trace.WriteLine("I AM BAR!");
        }
        static void Baz()
        {
            Trace.WriteLine("I AM BAZ!");
        }
        static void OnNoes(object sender, UnhandledExceptionEventArgs e)
        {
            Trace.WriteLine("OhNoes!");
        }
