    using System;
    using System.Xml.Linq;
    using System.Xml.Serialization;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                // Create XDocument to represent our XML file
                XDocument xdoc = XDocument.Load("XmlFile.xml");
    
                // Create a deserializer and break down our XML into c# objects
                XmlSerializer deserializer = new XmlSerializer(typeof(Settings));
    
                // Deserialize into a Settings object
                Settings settings = (Settings)deserializer.Deserialize(xdoc.CreateReader());
    
                // Check that we have some display settings
                if (null != settings.DisplaySettings)
                {
                    Screen screen = settings.DisplaySettings.Screen;
                    LocalPosition localPosition = screen.LocalPosition;
    
                    // Check to make sure we have a screen tag before using it
                    if (null != screen.ScreenTag)
                    {
                        Console.WriteLine("There is a name: " + screen.ScreenTag);
                    }
    
                    // We can just write our integers to the console, as we will get a document error when we
                    // try to parse the document if they are not provided!
                    Console.WriteLine("Position: " + localPosition.X + ", " + localPosition.Y + ", " + localPosition.Z);
                }            
    
                Console.ReadLine();
            }
        }
    
        [XmlRoot("Settings")]
        public class Settings
        {
            [XmlElement("Display_Settings")]
            public DisplaySettings DisplaySettings { get; set; }
        }
    
        public class DisplaySettings
        {
            [XmlElement("Screen")]
            public Screen Screen { get; set; }
        }
    
        public class Screen
        {
            [XmlElement("Name")]
            public string Name { get; set; }
    
            [XmlElement("ScreenTag")]
            public string ScreenTag { get; set; }
    
            [XmlElement("LocalPosition")]
            public LocalPosition LocalPosition { get; set; }
        }
    
        public class LocalPosition
        {
            [XmlAttribute("X")]
            public int X { get; set; }
    
            [XmlAttribute("Y")]
            public int Y { get; set; }
    
            [XmlAttribute("Z")]
            public int Z { get; set; }
        }
    }
