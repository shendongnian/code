    using System;
    using Newtonsoft.Json;
    
    public class Data
    {
        public CurrentLocation current_location { get; set; }
        public WorkHistory[] work_history { get; set; }
        public EducationHistory[] education_history { get; set; }
    }
    
    public class EducationHistory
    {
        public string name { get; set; }
        public int? year { get; set; }
        public string school_type { get; set; }
    }
    
    public class WorkHistory
    {
        public string company_name { get; set; }
        public Location location { get; set; }
    }
    
    public class CurrentLocation
    {
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
    }
    
    public class Location
    {
        public string city { get; set; }
        public string state { get; set; }
    }
    
    class Program
    {
        static void Main()
        {
            var json = 
            @"
            {
                ""current_location"": {
                    ""city"": ""Delhi"",
                    ""state"": ""Delhi"",
                    ""country"": ""India"",
                    ""zip"": """",
                    ""id"": 102161913158207,
                    ""name"": ""Delhi, India""
                },
                ""education_history"": [
                    {
                        ""name"": ""I E T , Alwar (Raj.)"",
                        ""year"": 2007,
                        ""concentrations"": [],
                        ""school_type"": ""College""
                    },
                    {
                        ""name"": ""Institute of Engineering and Technology, Alwar"",
                        ""concentrations"": [],
                        ""school_type"": ""College""
                    }
                ],
                ""work_history"": [
                    {
                        ""location"": {
                            ""city"": """",
                            ""state"": """"
                        },
                        ""company_name"": ""Defence Research & Development Organisation (DRDO)"",
                        ""description"": """",
                        ""start_date"": ""0000-00"",
                        ""end_date"": ""0000-00""
                    }
                ]
            }";
    
            Data soap = JsonConvert.DeserializeObject<Data>(json);
            Console.WriteLine(soap.current_location.city);
        }
    }
