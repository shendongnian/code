    public class Post_182e5e41_4625_4190_8a4d_4d4b13d131cb
    {
        [ServiceContract]
        public class Service
        {
            [OperationContract]
            [WebInvoke(Method = "POST",
                ResponseFormat = WebMessageFormat.Json,
                RequestFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest,
                UriTemplate = "savejson")]
            public bool SaveJSONData(string id, string fichier)
            {
                return true;
            }
        }
        public static void Test()
        {
            string baseAddress = "http://" + Environment.MachineName + ":8000/Service";
            WebServiceHost host = new WebServiceHost(typeof(Service), new Uri(baseAddress));
            host.Open();
            Console.WriteLine("Host opened");
            JObject json = new JObject();
            json.Add("id", JToken.FromObject("15"));
            json.Add("Fichier", "the file contents"); //System.IO.File.ReadAllText(@"C:\Dev\iECV\iECVMvcApplication\Content\fichier.json"));
            WebClient c = new WebClient();
            c.Headers[HttpRequestHeader.ContentType] = "application/json";
            string result = c.UploadString(baseAddress + "/savejson", json.ToString(Newtonsoft.Json.Formatting.None, null));
            JToken response = JToken.Parse(result);
            bool success = response.ToObject<bool>();
            Console.WriteLine(success);
            Console.Write("Press ENTER to close the host");
            Console.ReadLine();
            host.Close();
        }
    }
