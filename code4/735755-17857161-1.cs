    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    
    class Test
    {
        static void Main()
        {            
           string nextEvent = "[[\"nextData\", \"RANDOM MESSAGE\"], [\"moreInfo\", {\"num\": 3204}]]";
           JObject json = JObject.Parse("{\"j\":" + nextEvent + "}");
           string randomMessage = (string)json["j"][0][1]; 
           Console.WriteLine(randomMessage); // gives "RANDOM MESSAGE"
        }
    }
           
