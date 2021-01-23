    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Xml.Serialization;
    
    namespace Patterns
    {
        [Serializable()]
        public class Garage
        {
            public string GarageOwner { get; set; }
            public List<Vehicle> MyVehicles { get; set; }
        }
    
        [Serializable()]
        public class Vehicle
        {
            public string VehicleType { get; set; }
            public int VehicleNumber { get; set; }
        }
    
        class Serializer
        {
            static string _StartupPath = @"C:\temp\";
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
    
                    // Create some vehicles
                    var myVehicle1 = new Vehicle();
                    myVehicle1.VehicleType = "Car";
                    myVehicle1.VehicleNumber = 1234;
    
                    var myVehicle2 = new Vehicle();
                    myVehicle2.VehicleType = "Boat";
                    myVehicle2.VehicleNumber = 56234;
    
                    // Create a new instance and add the vehicles
                    MyGarage.MyVehicles = new List<Vehicle>()
                    {
                        myVehicle1, 
                        myVehicle2
                    };
    
                    WriteGarageXML(MyGarage);
                    Console.WriteLine("Serialized");
                }
                else if (cki.KeyChar.ToString() == "r")
                {
                    Garage MyGarage = ReadGarageXML();
                    Console.WriteLine("Deserialized Garage owned by " +  MyGarage.GarageOwner);
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
