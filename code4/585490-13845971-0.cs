    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using TerraServiceExample.com.msrmaps; // add the service using statement
    // http://msrmaps.com/terraservice2.asmx
    namespace TerraServiceExample
    {
        class Program
        {
            /// <summary> The main entry point for the application. </summary>
            static void Main(string[] args)
            {
    
                // Create the GPS point from your location services data
                LonLatPt location = new LonLatPt();
    
                // Modify Lat and Lon based on your needs
                // This example uses the GPS Coordinates for "Eau Claire, Wisconsin, United States"
                location.Lat = 44.811349;
                location.Lon = -91.498494;
    
                // Create a new TerraService object
                TerraService ts = new TerraService();
    
                // Output the nearest location from the TerraService
                Console.WriteLine(ts.ConvertLonLatPtToNearestPlace(location));
    
                // For console app to stay open/close easily
                Console.WriteLine("Press any key to close window...");
                Console.ReadKey();
    
                // Lastly, appreciate the Microsoft folks that made this available for free
                // They are all interesting individuals but you should read about Jim Gray via Wikipedia to
                // understand some history behind this cool web service.
            }
        }
    }
