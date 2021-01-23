    using System.Collections.Generic;
    
    namespace SettingsDict
    {
        class Program
        {
            static void Main(string[] args)
            {
                // call the extension method by adding .Settings();
                //Dictionary<string, string> settings = new Dictionary<string, string>().Settings();
                // Or by using the property in the Constants class
                var mySettings = Constants.settings;
            }
        }
        public class Constants
        {
            public static Dictionary<string, string> settings
            {
                get
                {
                    return new Dictionary<string, string>().Settings();
                }
            }
        }
    
        public static class Extensions
        {
            public static Dictionary<string, string> Settings(this Dictionary<string, string> myDict)
            {
                // Read and split
                string[] settings = System.IO.File.ReadAllLines(@"settings.txt");
    
                foreach (string line in settings)
                {
                    // split on =
                    var split = line.Split(new[] { '=' });
    
                    // Break if incorrect lenght
                    if (split.Length != 2)
                        continue;
    
                    // add the values to the dictionary
                    myDict.Add(split[0].Trim(), split[1].Trim());
                }
                return myDict;
            }
        }
    }
