    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Xml.Linq;
    namespace Demo
    {
        class Program
        {
            void run()
            {
                XDocument doc = XDocument.Load("C:\\TEST\\TEST.XML");
                var filenames = ExtractFilenamesAndHashes(doc);
                filenames.Print();
            }
            public IEnumerable<string> ExtractFilenamesAndHashes(XDocument doc)
            {
                return extractFilenamesAndHashes(doc.Root, doc.Root.Attribute("name").Value);
            }
            IEnumerable<string> extractFilenamesAndHashes(XElement root, string path)
            {
                foreach (var folder in root.Elements("dir"))
                    foreach (var filename in extractFilenamesAndHashes(folder, Path.Combine(path, folder.Attribute("name").Value)))
                        yield return filename;
                foreach (var file in root.Elements("file"))
                    yield return Path.Combine(path, file.Attribute("name").Value + ", " + file.Attribute("md5").Value);
            }
            static void Main()
            {
                new Program().run();
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
        }
    }
                                                                              
