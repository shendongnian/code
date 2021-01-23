    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Xml;
    using System.Xml.Serialization;
    
    namespace Patterns
    {
        public class Garage
        {
            private Vehicle _MyVehicle;
    
            public Garage()
            {
            }
            public string GarageOwner { get; set; }
    
            public Vehicle MyVehicle
            {
                get { return _MyVehicle; }
                set { _MyVehicle = value; }
            }
        }
    
        [XmlInclude(typeof(Car))]
        [XmlInclude(typeof(Boat))]
        [XmlInclude(typeof(Motorcycle))]
        [XmlInclude(typeof(Motorhome))]
        public abstract class Vehicle
        {
            public string VehicleType { get; set; }
            public int VehicleNumber { get; set; }
        }
        public class Car : Vehicle
        {
            public int Doors { get; set; }
        }
        public class Boat : Vehicle
        {
            public int Engines { get; set; }
        }
        public class Motorcycle : Vehicle
        {
            public int Wheels { get; set; }
        }
        public class Motorhome : Vehicle
        {
            public int Length { get; set; }
        }
    
        class Serializer
        {
            static string _StartupPath = @"C:\Projects\Patterns\Data\";
            static string _StartupFile = "SerializerTest.xml";
            static string _StartupXML = _StartupPath + _StartupFile;
    
            static void Main(string[] args)
            {
                Console.Write("Press w for write. Press r for read:");
                ConsoleKeyInfo cki = Console.ReadKey(true);
                Console.WriteLine("Pressed: " + cki.KeyChar.ToString());
                if (cki.KeyChar.ToString() == "w")
                {
                    Garage MyGarage = new Garage();
                    MyGarage.GarageOwner = "John";
                    Car c = new Car();
                    c.VehicleType = "Lexus";
                    c.VehicleNumber = 1234;
                    c.Doors = 4;
                    MyGarage.MyVehicle = c;
                    WriteGarageXML(MyGarage);
                    Console.WriteLine("Serialized");
                }
                else if (cki.KeyChar.ToString() == "r")
                {
                    Garage MyGarage = ReadGarageXML();
                    Console.WriteLine("Deserialized Garage owned by " + MyGarage.GarageOwner);
                }
                Console.ReadKey();
            }
            public static void WriteGarageXML(Garage pInstance)
            {
                XmlSerializer writer = new XmlSerializer(typeof(Garage));
                using (FileStream file = File.OpenWrite(_StartupXML))
                {
                    writer.Serialize(file, pInstance);
                }
            }
            public static Garage ReadGarageXML()
            {
                XmlSerializer reader = new XmlSerializer(typeof(Garage));
                using (FileStream input = File.OpenRead(_StartupXML))
                {
                    return reader.Deserialize(input) as Garage;
                }
            }
        }    
    }
