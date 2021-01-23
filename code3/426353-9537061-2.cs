    namespace JsonFun
    {
    	using System;
    	using System.Net;
    	using Newtonsoft.Json;
    
    	class Program
    	{
    		private const string Url = "https://api.qualifiedaddress.com/street-address/?street=1600%20Amphitheatre%20Parkway&street2=&city=Mountain%20View&state=CA&zipcode=94043&candidates=10&auth-token=YOUR_AUTH_TOKEN_HERE";
    
    		static void Main()
    		{
    			using (var webClient = new WebClient())
    			{
    				var json = webClient.DownloadString(Url);
    
    				var candidate_addresses = JsonConvert.DeserializeObject<CandidateAddress[]>(json);
    				foreach (var item in candidate_addresses)
    					Console.WriteLine(item.metadata.county_name);
    
    				Console.ReadLine();
    			}
    		}
    	}
    
    	public class CandidateAddress
    	{
    		public int input_index { get; set; }
    		public int candidate_index { get; set; }
    		public string delivery_line_1 { get; set; }
    		public string last_line { get; set; }
    		public string delivery_point_barcode { get; set; }
    		public Components components { get; set; }
    		public Metadata metadata { get; set; }
    		public Analysis analysis { get; set; }
    	}
    
    	public class Components
    	{
    		public string primary_number { get; set; }
    		public string street_name { get; set; }
    		public string street_suffix { get; set; }
    		public string city_name { get; set; }
    		public string state_abbreviation { get; set; }
    		public string zipcode { get; set; }
    		public string plus4_code { get; set; }
    		public string delivery_point { get; set; }
    		public string delivery_point_check_digit { get; set; }
    	}
    
    	public class Metadata
    	{
    		public string record_type { get; set; }
    		public string county_fips { get; set; }
    		public string county_name { get; set; }
    		public string carrier_route { get; set; }
    		public string congressional_district { get; set; }
    		public double latitude { get; set; }
    		public double longitude { get; set; }
    		public string precision { get; set; }
    	}
    
    	public class Analysis
    	{
    		public string dpv_match_code { get; set; }
    		public string dpv_footnotes { get; set; }
    		public string dpv_cmra { get; set; }
    		public string dpv_vacant { get; set; }
    		public bool ews_match { get; set; }
    		public string footnotes { get; set; }
    	}
    }
