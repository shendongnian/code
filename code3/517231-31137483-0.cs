    public class SoundCloudService : ISoundPlatformService
    {
        public SoundCloudService()
        {
            Errors=new List<string>();
        }
        private const string baseAddress = "https://api.soundcloud.com/";
        public IList<string> Errors { get; set; }
        public async Task<string> GetNonExpiringTokenAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);
                var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("client_id","xxxxxx"),
                    new KeyValuePair<string, string>("client_secret","xxxxxx"),
                    new KeyValuePair<string, string>("grant_type","password"),
                    new KeyValuePair<string, string>("username","xx@xx.com"),
                    new KeyValuePair<string, string>("password","xxxxx"),
                    new KeyValuePair<string, string>("scope","non-expiring")
                });
                var response = await client.PostAsync("oauth2/token", content);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    dynamic data = JsonConvert.DeserializeObject(await response.Content.ReadAsStringAsync());
                    return data.access_token;
                }
                Errors.Add(string.Format("{0} {1}", response.StatusCode, response.ReasonPhrase));
                return null;
            }
        }        
        public async Task UploadTrackAsync(string filePath)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress=new Uri(baseAddress);
             
                var form = new MultipartFormDataContent(Guid.NewGuid().ToString());
                var contentTitle = new StringContent("Test");
                contentTitle.Headers.ContentType = null;
                form.Add(contentTitle, "track[title]");
                var contentSharing = new StringContent("private");
                contentSharing.Headers.ContentType = null;
                form.Add(contentSharing, "track[sharing]");
                var contentToken = new StringContent("xxxxx");
                contentToken.Headers.ContentType = null;
                form.Add(contentToken, "[oauth_token]");
                var contentFormat = new StringContent("json");
                contentFormat.Headers.ContentType = null;
                form.Add(contentFormat, "[format]");
                var contentFilename = new StringContent("test.mp3");
                contentFilename.Headers.ContentType = null;
                form.Add(contentFilename, "[Filename]");
                var contentUpload = new StringContent("Submit Query");
                contentUpload.Headers.ContentType = null;                                
                form.Add(contentUpload, "[Upload]");
                var contentTags = new StringContent("Test");
                contentTags.Headers.ContentType = null;
                form.Add(contentTags, "track[tag_list]");
                var bytes = File.ReadAllBytes(filePath);                
                var contentFile = new ByteArrayContent(bytes, 0, bytes.Count());                
                contentFile.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                form.Add(contentFile, "track[asset_data]", "test.mp3");
                var response = await client.PostAsync("tracks", form);                
            }
        }
    }
