    using System.Newtonsoft.Json;
    using System.Newtonsoft.Json.Linq;
    using System.Net;
     static void Main(string[] args)
        {
            WebClient c = new WebClient();
            var data = c.DownloadString("http://www.taxmann.com/TaxmannWhatsnewService/Services.aspx?service=gettopstoriestabnews");
            
            JObject o = JObject.Parse(data);
            Response.Write("NewsID: "+ o["news_id"]);
            Response.Write("NewsTitle: " + o["news_title"]);
            
 
        }
