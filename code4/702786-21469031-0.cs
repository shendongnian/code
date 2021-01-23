    //I disclaimer everything and note that I haven't re-checked if this posted code works.
    using System;
    using System.Text;
    using System.Collections.Generic;
    using Newtonsoft.Json;  //install with Nuget package installer- "json.Net"
    using System.Net.Http;  //install with Nuget package installer- "...Web API client libraries"
    using System.Net;
    using System.IO;
    using System.Runtime.Serialization.Json;       //security risk till certificate fixed
 
    namespace CSharpDemoCodeConsole
    {
        class Program
        {
            const string api_key = "your_api_key"; //set your api_key here
            const string user_auth = "your_username" + ":" + "your_password"; // set your user credentials here
            const string urlBase = "https://@SECRET.com@/api/v1";
 
            static void Main(string[] args)
            {
                Console.WriteLine("Making call to webserver asynchronously");
                MakeCallAsynchronously();
                Console.WriteLine("**************************************");
 
                Console.WriteLine("Making call to webserver synchronously");
                MakeCallSynchronously();
                Console.WriteLine("**************************************");
 
                Console.WriteLine("Making call to webserver synchronously without Newtonsoft serialization");
                MakeCallSynchronouslyWithoutNewtonSoft();
                Console.WriteLine("Press spacebar to close the application");
                Console.ReadKey();
            }
 
            private static void MakeCallAsynchronously()
            {
                //Always accept untrusted certificates - don't use in production
                ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
 
                //Setup request
                string authorizeString = Convert.ToBase64String(Encoding.ASCII.GetBytes(user_auth));
                HttpClient httpRequest = new HttpClient();
                httpRequest.DefaultRequestHeaders.Add("Authorization", "Basic " + authorizeString);
                httpRequest.DefaultRequestHeaders.Add("Accept", "application/json");
 
                //GET from places resource
                try
                {
                    var requestTask = httpRequest.GetAsync(urlBase + "places/" + "?api_key=" + api_key,
                    System.Net.Http.HttpCompletionOption.ResponseContentRead);
 
                    //Update UI while waiting for task to complete
                    while (requestTask.Status != System.Threading.Tasks.TaskStatus.RanToCompletion)
                    {
                        Console.Write(".");
                        System.Threading.Thread.Sleep(30);
                    }
                    if (requestTask.Result.StatusCode != HttpStatusCode.OK)
                    {
                        Console.WriteLine("Unexpected response from server: {0}", requestTask.Result);
                        return;
                    }
                    var places = JsonConvert.DeserializeObject<Page<Place>>(requestTask.Result.Content.ReadAsStringAsync().Result);
                    Console.WriteLine("GET places response " + requestTask.Result.Content.ReadAsStringAsync().Result);
                }
                catch (WebException ex)
                {
                    Console.WriteLine(ex.ToString());
                    return;
                }
 
                //POST to places resource
                try
                {
                    string jsonString = JsonConvert.SerializeObject(new Place { name = "test place", latitude = 0, longitude = 0 });
                    HttpContent payload = new StringContent(jsonString, Encoding.UTF8, "application/json");
                    var requestTask = httpRequest.PostAsync(urlBase + "places/" + "?api_key=" + api_key, payload);
 
                    //Update UI while waiting for task to complete
                    while (requestTask.Status != System.Threading.Tasks.TaskStatus.RanToCompletion)
                    {
                        Console.Write(".");
                        System.Threading.Thread.Sleep(30);
                    }
                    if (requestTask.Result.StatusCode != HttpStatusCode.Created)
                    {
                        Console.WriteLine("Unexpected response from server: {0}", requestTask.Result);
                        return;
                    }
                    Console.WriteLine("POST places response " + requestTask.Result.Content.ReadAsStringAsync().Result);
                }
                catch (WebException ex)
                {
                    Console.WriteLine(ex.ToString());
                    return;
                }
            }
 
            private static void MakeCallSynchronously()
            {
                //Always accept untrusted certificates - don't use in production
                ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
 
                //Setup Request
                string authorizeString = Convert.ToBase64String(Encoding.ASCII.GetBytes(user_auth));
                var client = new WebClient();
                client.Headers.Add("Authorization", "Basic " + authorizeString);
                client.Headers.Add("Accept", "application/json");
 
                //GET from places resource
                try
                {
                    var responseStream = client.OpenRead(urlBase + "places/" + "?api_key=" + api_key);
                    var response = (new StreamReader(responseStream).ReadToEnd());
                    var places = JsonConvert.DeserializeObject<Page<Place>>(response);
                    Console.WriteLine("GET places response " + response);
                }
                catch (WebException ex)
                {
                    Console.WriteLine(ex.ToString());
                }
 
                //POST to places resource
                try
                {
                    client.Headers.Add("Accept", "application/json");
                    client.Headers.Add("Content-Type", "application/json");
                    string jsonString = JsonConvert.SerializeObject(new Place { name = "test place", latitude = 0, longitude = 0 });
                    client.Encoding = System.Text.Encoding.UTF8;
                    string response = client.UploadString(urlBase + "places/" + "?api_key=" + api_key, jsonString);
                    Console.WriteLine("POST places response " + response);
                }
                catch (WebException ex)
                {
                    Console.WriteLine(ex.ToString());
                    return;
                }
            }
 
            private static void MakeCallSynchronouslyWithoutNewtonSoft()
            {
                //Always accept untrusted certificates - don't use in production
                ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
 
                //Setup Request
                string authorizeString = Convert.ToBase64String(Encoding.ASCII.GetBytes(user_auth));
                var client = new WebClient();
                client.Headers.Add("Authorization", "Basic " + authorizeString);
                client.Headers.Add("Accept", "application/json");
 
                //GET from places resource
                try
                {
                    var responseStream = client.OpenRead(urlBase + "places/" + "?api_key=" + api_key);
                    MemoryStream ms = new MemoryStream();
                    responseStream.CopyTo(ms);
                    ms.Position = 0;
                    var placesDeserializer = new DataContractJsonSerializer(typeof(Page<Place>));
                    var places = (Page<Place>)placesDeserializer.ReadObject(ms);
                    ms.Position = 0;
                    string response = (new StreamReader(ms).ReadToEnd());
                    ms.Close();
                    Console.WriteLine("GET places response " + response);
                }
                catch (WebException ex)
                {
                    Console.WriteLine(ex.ToString());
                    return;
                }
 
                //POST to places resource
                try
                {
                    client.Headers.Add("Accept", "application/json");
                    client.Headers.Add("Content-Type", "application/json");
                    DataContractJsonSerializer placesSerializer = new DataContractJsonSerializer(typeof(Place));
                    Place place = new Place { name = "test place", latitude = 0, longitude = 0 };
                    MemoryStream ms = new MemoryStream();
                    placesSerializer.WriteObject(ms, place);
                    byte[] json = ms.ToArray();
                    ms.Close();
                    string jsonString = Encoding.UTF8.GetString(json, 0, json.Length);
                    client.Encoding = System.Text.Encoding.UTF8;
                    string response = client.UploadString(urlBase + "places/" + "?api_key=" + api_key, jsonString);
                    Console.WriteLine("POST places response " + response);
 
                }
                catch (WebException ex)
                {
                    Console.WriteLine(ex.ToString());
                    return;
                }
            }
        }
 
        public class Place
        {
            [JsonProperty("url")]
            public string url { get; set; }
            [JsonProperty("name")]
            public string name { get; set; }
            [JsonProperty("latitude")]
            public float latitude { get; set; }
            [JsonProperty("longitude")]
            public float longitude { get; set; }
        }
 
        public class Page<T>
        {
            [JsonProperty("count")]
            public int count { get; set; }
            [JsonProperty("next")]
            public string next { get; set; }
            [JsonProperty("previous")]
            public string previous { get; set; }
            [JsonProperty("results")]
            public List<T> results { get; set; }
        }
    }
