    using System;
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;
    namespace SerializationExample
    {
        class Program
        {
            static void Main(string[] args)
            {
                string[] FileNames = new string[] {
                    @"model1.bin",
                    @"model2.bin"
                };
                Stream[] files = new Stream[] {
                    File.Create(FileNames[0]),
                    File.Create(FileNames[1])
                };
                BinaryFormatter bf = new BinaryFormatter();
                Model m1 = new Model();
                m1.B = new AnotherClass("Set in app");
                m1.A.Value = "Set in app";
                Model m2 = new Model();
                Console.WriteLine("M1:\n{0}\n", m1);
                Console.WriteLine("M2:\n{0}\n\n", m2);
                bf.Serialize(files[0], m1);
                bf.Serialize(files[1], m2);
                foreach (var f in files)
                    f.Seek(0, SeekOrigin.Begin);
                m1 = null;
                m2 = null;
                m1 = (Model)bf.Deserialize(files[0]);
                m2 = (Model)bf.Deserialize(files[1]);
                Console.WriteLine("M1:\n{0}\n", m1);
                Console.WriteLine("M2:\n{0}\n\n", m2);
                foreach (var f in files)
                    f.Close();           
            }
        }
    }
