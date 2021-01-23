    namespace SamplePlugin
    {
        public class MySamplePlugin : MyPluginBase
        {
            public MySamplePlugin()
            { }
            public override void DrawingControl()
            {
                var color = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("----------------------");
                Console.WriteLine("This was called from app domian {0}", AppDomain.CurrentDomain.FriendlyName );
                Console.WriteLine("I have following assamblies loaded:");
                foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
                {
                    Console.WriteLine("\t{0}", assembly.GetName().Name);
                }
                Console.WriteLine("----------------------");
                Console.ForegroundColor = color;
            }
        }
    }
