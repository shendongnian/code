    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Text;
    using System.Json;
     
    namespace ConsoleApplication2
    {
        class Program
        {
            private const string URL = "https://XXXX/rest/api/2/component";
            private const string DATA = @"{
        ""name"": ""Component 2"",
        ""description"": ""This is a JIRA component"",
        ""leadUserName"": ""xx"",
        ""assigneeType"": ""PROJECT_LEAD"",
        ""isAssigneeTypeValid"": false,
        ""project"": ""TP""}";
            static void Main(string[] args)
            {
                AddComponent();
            }
     
            private static void AddComponent()
            {
                System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();
                client.BaseAddress = new System.Uri(URL);
                byte[] cred = UTF8Encoding.UTF8.GetBytes("username:password");
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(cred));
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
     
                System.Net.Http.HttpContent content = new StringContent(DATA, UTF8Encoding.UTF8, "application/json");
                HttpResponseMessage messge = client.PostAsync(URL, content).Result;
                string description = string.Empty;
                if (messge.IsSuccessStatusCode)
                {
                    string result = messge.Content.ReadAsStringAsync().Result;
                    description = result;
                }
            }
        }
    }
