    using System;
    using System.Reflection;
    using System.IO;
    namespace DotNetInspectorGadget
    {
        class DotNetInspectorGadget 
        {
            static int Main(string[] args) 
            {
              if(args.GetLength(0) < 1)
              {
                Console.WriteLine("Add a single parameter that is your" +
                " path to the file you want inspected.");
                return 1;
              }
              try {
                    var assemblies = Assembly.LoadFile(@args[0]).GetReferencedAssemblies();
                    
                    if (assemblies.GetLength(0) > 0)
                    {
                      foreach (var assembly in assemblies)
                      {
                        Console.WriteLine(assembly);
                      }
                      return 0;
                    }
              }
              catch(Exception e) {
                Console.WriteLine("An exception occurred: {0}", e.Message);
                return 1;
              } finally{}
              
                return 1;
            }
        }
    }
