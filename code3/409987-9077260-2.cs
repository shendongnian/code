    using System.Reflection;
...
    public class GlobalClass
    {
        public GlobalClass()
        {
            Type[] types = Assembly.GetExecutingAssembly ().GetTypes ();
            foreach ( Type t in types )
            {
                if ( t.BaseType == typeof ( BaseClass ) )
                {
                    Console.WriteLine ( "I found a class " + t.Name + " that subclass BaseClass" );
                }
            }
        }
    }
