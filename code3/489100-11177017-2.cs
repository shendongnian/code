    namespace PlaceFinder
    {
        public class YahooResponse
        {
            public ResultSet ResultSet { get; set; }
        }
    
        public class ResultSet
        {
            public string version { get; set; }
            public int Error { get; set; }
            public string ErrorMessage { get; set; }
            public string Locale { get; set; }
            public int Quality { get; set; }
            public int Found { get; set; }
            public Result[] results { get; set; }
        }
    
        public class Result
        {
            public int quality { get; set; }
            public string latitude { get; set; }
            public string longitude { get; set; }
            public string offsetlat { get; set; }
            public string offsetlon { get; set; }
            public int radius { get; set; }
            public string name { get; set; }
            public string line1 { get; set; }
            public string line2 { get; set; }
            public string line3 { get; set; }
            public string line4 { get; set; }
            public string house { get; set; }
            public string street { get; set; }
            public string xstreet { get; set; }
            public string unittype { get; set; }
            public string unit { get; set; }
            public string postal { get; set; }
            public string neighborhood { get; set; }
            public string city { get; set; }
            public string county { get; set; }
            public string state { get; set; }
            public string country { get; set; }
            public string countrycode { get; set; }
            public string statecode { get; set; }
            public string countycode { get; set; }
            public string uzip { get; set; }
            public string hash { get; set; }
            public long woeid { get; set; }
            public int woetype { get; set; }
        }
    }
