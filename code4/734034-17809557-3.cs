    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    namespace Demo
    {
        class Program
        {
            private void run()
            {
                string root = "F:\\TFROOT";
                Action test1 = () => leafFolders1(root).Count();
                Action test2 = () => leafFolders2(root).Count();
                for (int i = 0; i < 10; ++i)
                {
                    test1.TimeThis("Using linq.");
                    test2.TimeThis("Using yield.");
                }
            }
            static void Main()
            {
                new Program().run();
            }
            static IEnumerable<string> leafFolders1(string root)
            {
                var folderWithoutSubfolder = Directory.EnumerateDirectories(root, "*.*", SearchOption.AllDirectories)
                     .Where(f => !Directory.EnumerateDirectories(f, "*.*", SearchOption.TopDirectoryOnly).Any());
                return folderWithoutSubfolder;
            }
            static IEnumerable<string> leafFolders2(string root)
            {
                bool anySubfolders = false;
                foreach (var subfolder in Directory.EnumerateDirectories(root))
                {
                    anySubfolders = true;
                    foreach (var leafFolder in leafFolders2(subfolder))
                        yield return leafFolder;
                }
                if (!anySubfolders)
                    yield return root;
            }
        }
        static class DemoUtil
        {
            public static void Print(this object self)
            {
                Console.WriteLine(self);
            }
            public static void Print(this string self)
            {
                Console.WriteLine(self);
            }
            public static void Print<T>(this IEnumerable<T> self)
            {
                foreach (var item in self)
                    Console.WriteLine(item);
            }
            public static void TimeThis(this Action action, string title, int count = 1)
            {
                var sw = Stopwatch.StartNew();
                for (int i = 0; i < count; ++i)
                    action();
                Console.WriteLine("Calling {0} {1} times took {2}",  title, count, sw.Elapsed);
            }
        }
    }
