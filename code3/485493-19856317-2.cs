        /// <summary>
        /// Determines whether this instance [can get result from service].
        /// </summary>
        [Test]
        public void CanGetResultFromService()
        {
            string url = "http://httpbin.org/ip";
            Ip result;
            service.Get<Ip>(url,
            success =>
            {
                result = success;
            },
            error =>
            {
                Debug.WriteLine(error.Message);
            });
            Thread.Sleep(5000);
        }
        /// <summary>
        /// Determines whether this instance [can post result automatic service].
        /// </summary>
        [Test]
        public void CanPostResultToService()
        {
            string url = "http://httpbin.org/post";
            string data = "{\"test\":\"hoi\"}";
            HttpBinResponse result = null;
            service.Post<HttpBinResponse>(url, data,
                response =>
                {
                    result = response;
                },
                error =>
                {
                    Debug.WriteLine(error.Message);
                });
            Thread.Sleep(5000);
        }
    }
    public class Ip
    {
        public string Origin { get; set; }
    }
    public class HttpBinResponse
    {
        public string Url { get; set; }
        public string Origin { get; set; }
        public Headers Headers { get; set; }
        public object Json { get; set; }
        public string Data { get; set; }
    }
    public class Headers
    {
        public string Connection { get; set; }
        [JsonProperty("Content-Type")]
        public string ContentType { get; set; }
        public string Host { get; set; }
        [JsonProperty("Content-Length")]
        public string ContentLength { get; set; }
    }
