    using System;
    using System.IO;
    using System.Runtime.Serialization;
    using System.Text;
    using System.Xml;
    using System.Xml.Xsl;
    [DataContract]
    public class Foo
    {
        [DataMember]
        public Bar Bar { get; set; }
    }
    [DataContract]
    public class Bar
    {
        [DataMember]
        public Foo Foo { get; set; }
    }
    static class Program
    {
        static void Main()
        {
            var foo = new Foo();
            var bar = new Bar();
            foo.Bar = bar;
            bar.Foo = foo;
            using (var ms = new MemoryStream())
            {
                var ser = new DataContractSerializer(typeof(Foo), new DataContractSerializerSettings {
                    PreserveObjectReferences = true
                });
                ser.WriteObject(ms, foo);
                Console.WriteLine(Encoding.UTF8.GetString(ms.GetBuffer(), 0, (int)ms.Length));
                Console.WriteLine();
                ms.Position = 0;
                var xslt = new XslCompiledTransform();
                xslt.Load("my.xslt");
                using (var reader = XmlReader.Create(ms))
                {
                    xslt.Transform(reader, null, Console.Out);
                }
            }
            Console.WriteLine();
            Console.WriteLine("press any key");
            Console.ReadKey();
        }
    }
