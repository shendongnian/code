    public class ShareInfo
            {
                [JsonIgnore]
                public readonly DateTime Timestamp = DateTime.Now;
                [JsonProperty("sharename")]
                public string ShareName = null;
                [JsonProperty("readystate")]
                public string ReadyState = null;
                [JsonProperty("created")]
                [JsonConverter(typeof(Newtonsoft.Json.Converters.UnixDateTimeConverter))]
                public DateTime? CreatedUtc = null;
                [JsonProperty("title")]
                public string Title = null;
                [JsonProperty("getturl")]
                public string GettUrl = null;
                [JsonProperty("userid")]
                public string UserId = null;
                [JsonProperty("fullname")]
                public string Fullname = null;
                [JsonProperty("files")]
                public GettFile.FileInfo[] Files = new GettFile.FileInfo[0];
            }
    
    // POST request.
                var gett = new WebClient { Encoding = Encoding.UTF8 };
                gett.Headers.Add("Content-Type", "application/json");
                byte[] request = Encoding.UTF8.GetBytes(jsonArgument.ToString());
                byte[] response = gett.UploadData(baseUri.Uri, request);
    
                // Response.
                var shareInfo = JsonConvert.DeserializeObject<ShareInfo>(Encoding.UTF8.GetString(response));
