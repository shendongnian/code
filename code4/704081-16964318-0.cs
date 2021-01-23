    using System;
    using System.IO;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Json;
    namespace test
    {
        public struct Color
        {
            public byte R { get; set; }
            public byte G { get; set; }
            public byte B { get; set; }
        }
        [DataContract]
        public class MyEntity
        {
            [DataMember]
            public String Name { get; set; }
            [DataMember]
            public Color Colour { get; set; }
            public MyEntity(string name, Color colour)
            {
                this.Name = name;
                this.Colour = colour;
            }
        }
        class Program
        {
            static DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(MyEntity));
            static MyEntity entitySave, entityLoad;
            static void Main(string[] args)
            {
                entitySave = new MyEntity("Entity1", new Color() { R = 50, G = 20, B = 50 });
                Serialize(entitySave, "savefile.json");
                bool success = Deserialize(ref entityLoad, "savefile.json");
                if (success && entityLoad.Name == entitySave.Name)
                    Console.WriteLine("It works!");
                else
                    Console.WriteLine("Uh-oh :(");
                Console.ReadLine();
            }
            static void Serialize(MyEntity entity, string fileName)
            {
                FileStream stream = new FileStream(fileName, FileMode.Create);
                serializer.WriteObject(stream, entity);
                stream.Close();
            }
            static bool Deserialize(ref MyEntity entity, string fileName)
            {
                if (!File.Exists(fileName)) return false;
                FileStream stream = new FileStream(fileName, FileMode.Open);
                entity = (MyEntity)serializer.ReadObject(stream);
                stream.Close();
                return true;
            }
        }
    }
