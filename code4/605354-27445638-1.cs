    namespace MEFCachingTest
    {
        using System;
        using System.ComponentModel.Composition;
        using System.ComponentModel.Composition.Hosting;
        using System.ComponentModel.Composition.Primitives;
        using System.Diagnostics;
        using System.Reflection;
        public static class Program
        {
            public static CompositionContainer Container { get; set; }
            public static ComposablePartCatalog Catalog { get; set; }
            public static ExportedClass NonCachedClass
            {
                get
                {
                    return Container.GetExportedValue<ExportedClass>();
                }
            }
            private static ExportedClass cachedClass;
            public static ExportedClass CachedClass
            {
                get
                {
                    return cachedClass ?? (cachedClass = Container.GetExportedValue<ExportedClass>());
                }
            }
            public static void Main()
            {
                Catalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());
                Container = new CompositionContainer(Catalog);
                const int Runs = 1000000;
                var stopwatch = new Stopwatch();
                // Non-Cached.
                stopwatch.Start();
                for (int i = 0; i < Runs; i++)
                {
                    var ncc = NonCachedClass;
                }
                stopwatch.Stop();
                Console.WriteLine("Non-Cached: Time: {0}", stopwatch.Elapsed);
                // Cached.
                stopwatch.Restart();
                for (int i = 0; i < Runs; i++)
                {
                    var cc = CachedClass;
                }
                stopwatch.Stop();
                Console.WriteLine("    Cached: Time: {0}", stopwatch.Elapsed);
            }
        }
        [Export]
        [PartCreationPolicy(CreationPolicy.Shared)]
        public class ExportedClass
        {
        }
    }
