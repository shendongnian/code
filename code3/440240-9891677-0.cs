    public class UriFetcher
    {
        public Uri Get(string apiUri)
        {
            using (var httpClient = new HttpClient())
            {
                var httpResponseMessage = httpClient.GetAsync(apiUri).Result;
                return httpResponseMessage.RequestMessage.RequestUri;
            }
        }
    }
    [TestFixture]
    public class UriFetcherTester
    {
        [Test]
        public void Get()
        {
            var uriFetcher = new UriFetcher();
            var fetchedUri = uriFetcher.Get("https://api.twitter.com/1/users/profile_image?screen_name=twitterapi&size=bigger");
            Console.WriteLine(fetchedUri);
        }
    }
