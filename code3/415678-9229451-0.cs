    class Program {
            static void Main(string[] args)
            {
                    string json = @"
                    {
                            ""street_address"":""My street address"",
                            ""city"":""My City"",
                            ""state_province"":""My State Province"",
                            ""zip_postal_code"":""My Zip Postal Code"",
                    }";
    
                    Address address = JsonConvert.DeserializeObject<Address>(json);
                    Console.WriteLine("Street address: {0}", address.StreetAddress);
                    Console.WriteLine("City: {0}", address.City);
                    Console.WriteLine("State province: {0}", address.StateProvince);
                    Console.WriteLine("Zip postal code: {0}", address.ZipPostalCode);
            }
    }
    
    public class Address {
            [JsonProperty("street_address")]
            public string StreetAddress { get; set; }
    
            [JsonProperty("city")]
            public string City { get; set; }
    
            [JsonProperty("state_province")]
            public string StateProvince { get; set; }
    
            [JsonProperty("zip_postal_code")]
            public string ZipPostalCode { get; set; }
    }
