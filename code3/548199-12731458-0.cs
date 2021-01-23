    using System;
    using System.Timers;
    using System.Xml.Linq;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace ConsoleApplication1 {
        class Program {
            static void Main(string[] args) {
    
                var fileName = "C:\\gpsData.kml";
    
                var xml = XDocument.Load(fileName);
                var xmlns = xml.Root.Name.Namespace;
                var document = xml.Root.Element(xmlns.GetName("Document"));
                var placemark = document.Element(xmlns.GetName("Placemark"));
                var lineString = placemark.Element(xmlns.GetName("LineString"));
                var coordinates = lineString.Element(xmlns.GetName("coordinates"));
    
                var inc = 0;
                var timer = new Timer();
                var timer_Elapsed = new ElapsedEventHandler((s, e) => {
                    
                    // get the new coordinate here
                    var newCoordinate = "-112.2550785337791,36.07954952145647,2357";
                    var oldValue = coordinates.Value;
                    var newValue = oldValue + Environment.NewLine + newCoordinate;
                    coordinates.Value = newValue;
    
                    xml.Save(fileName);
    
                    inc++;
                });
    
                timer.Interval = 1000;
                timer.Elapsed += timer_Elapsed;
                timer.Start();
    
                while (10 > inc) ;
    
                timer.Stop();
                timer.Elapsed -= timer_Elapsed;
            }
        }
    }
