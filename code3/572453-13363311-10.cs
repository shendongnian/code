    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ReleaseEvents
    {
        class Program
        {
            public static event EventHandler SomethingHappened;
            static void Main( string[] args )
            {
                using ( var l_dependent = new Dependent() )
                {
                    SomethingHappened( null, EventArgs.Empty );
                }
                // Just to prove the point, garbage collection
                // will not clean up the dependent object, even
                // though it has been disposed.
                GC.Collect();
                try
                {
                    // This call will cause the disposed object
                    // (which is still registered to the event)
                    // to throw an exception.
                    SomethingHappened( null, EventArgs.Empty );
                }
                catch ( InvalidOperationException e )
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine( e.ToString() );
                }
                Console.ReadKey( true );
            }
        }
        class Dependent : IDisposable
        {
            private object _resource;
            public Dependent()
            {
                Program.SomethingHappened += Program_SomethingHappened;
                _resource = new object();
            }
            private void Program_SomethingHappened( object sender, EventArgs e )
            {
                if ( _resource == null )
                    throw new InvalidOperationException( "Resource cannot be null!" );
                Console.WriteLine( "SomethingHappened processed successfully!" );
            }
            public void Dispose()
            {
                _resource = null;
            }
        }
    }
