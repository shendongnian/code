    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace LinqFun
    {
        class Program
        {
            static void Main(string[] args)
            {
                //Set Data
                string jsonString = @"[
                                          {
                                            ""Key"": ""RegistrationWrx"",
                                            ""Value"": ""Wrx45687"",
                                            ""Id"": 462,
                                          },
                                          {
                                            ""Key"": ""IsConsentGiven"",
                                            ""Value"": ""True"",
                                            ""Id"": 463,
                                          }
                                       ]";
    
                //Create a list of CustomData entries to look through.
                List<CustomData> customData = JsonConvert.DeserializeObject<List<CustomData>>(jsonString);
    
    
                //Create an object for the is consent given block of data
    
                CustomData IsConsentGiven = customData.FirstOrDefault(x => x.Key == "IsConsentGiven");
    
                //check the linq query resulted in an object
                if (IsConsentGiven != null)
                {
                    Console.WriteLine(IsConsentGiven.Value);
                }
    
                Console.ReadLine();
            }
        }
    
         public class CustomData{
             public string Key { get; set; }
            public string Value { get; set; }
            public int? ID { get; set; }
        }
    }
 
