     using Newtonsoft.Json.Linq;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace Google_Padouri
    {
        class Program
        {
            static void Main(string[] args)
            {
                Google obj = new Google();
                obj.Execute();
            }
        
    }
    class Google
    {
        public void Execute()
        {
            string result = string.Empty;
            try
            {
                Console.WriteLine("Enter complete csv path");
                string path = Console.ReadLine();
                //string path = @"C:\tmp\google\test_file.csv";
                string[] rows = File.ReadAllLines(path);
                StringBuilder sb = new StringBuilder();
                int count = 0;
                foreach(string row in rows)
                {
                    string[] arr = row.Split(',');
                    string lat = arr[0];
                    string lng = arr[1];
                    if (count > 0) 
                    {
                        result = GetResult(lat, lng);
                        if (result.Length > 1)
                        {
                            result = GetAddress(result);
                            if (result.Length > 1)
                            {
                                Console.WriteLine("Working on row number " + count);
                                sb.Append(lat + "," + lng + "," + result.Replace(",", "") + "\n");
                                //if(count==200)
                                //{
                                //    break;
                                //}
                            }
                            else
                            {
                                Console.WriteLine("Could not fetch results");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Google API response failed");
                        }
                    }
                    count = count+1;
                }
                string dir = Path.GetDirectoryName(path);
                string file = Path.GetFileNameWithoutExtension(path);
                file = file + "_output.csv";
                string fullpath = dir + "\\" + file;
                using (StreamWriter wrtier = File.CreateText(fullpath))
                {
                    wrtier.Write(sb.ToString());
                }
                Console.Write("File compiled successfully");
                Console.Read();
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }
        public string GetResult(string lat,string lang)
        {
            string method = "GET";
            string URL = "https://maps.googleapis.com/maps/api/geocode/json?";
            string Key = "key=YOUR_KEY";
            string Sensor = "sensor=false&";
            string latlng = "latlng=" + lat + "," + lang;
            string result = string.Empty;
            URL = URL + Key + Sensor + latlng;
            try
            {
                using (WebClient wc = new WebClient())
                {
                    wc.Headers[HttpRequestHeader.ContentType] = "application/json";
                    wc.Encoding = Encoding.UTF8;
                    wc.Headers.Add("User-Agent: Other");
                    switch (method.ToUpper())
                    {
                        case "GET":
                            result = wc.DownloadString(URL);
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                Console.Read();
            }
            return result;
        }
        public string GetAddress(string data)
        {
            string result = string.Empty;
            try
            {
                if (data.Length > 1)
                {
                    JToken token = JToken.Parse(data);
                    JArray array = JArray.Parse(token["results"].ToString());
                    
                        
                        result = array.First["formatted_address"].ToString();
                    
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.Read();
            }
            return result;
        }
 
       }
    
    }
