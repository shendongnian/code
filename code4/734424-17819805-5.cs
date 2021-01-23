        class Program
        {
            static void Main(string[] args)
            {
                var jsSettings = new JsonSerializerSettings();
                var fs = new AngryHackerFlightSelection();
                string json = JsonConvert.SerializeObject(fs, Newtonsoft.Json.Formatting.None, jsSettings);
                Console.WriteLine(json);
            }
        }
    
        public class AngryHackerFlightSelection : FlightSelection
        {
            public override bool Equals(object obj)
            {
                var flightSelection = obj as FlightSelection;
                if (flightSelection == null)
                    return false;
                return Equals(flightSelection);
            }
        }
