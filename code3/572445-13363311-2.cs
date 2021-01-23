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
                var l_dependent = new Dependent();
                SomethingHappened( null, EventArgs.Empty );
                l_dependent.Dispose();
                // This call will cause the disposed object
                // (which is still registered to the event)
                // to thrown an exception.
                SomethingHappened( null, EventArgs.Empty );
            }
        }
        class Dependent : IDisposable
        {
            private object _resource;
            public Dependent()
            {
                _resource = new object();
                Program.SomethingHappened += Program_SomethingHappened;
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
