    protected void Page_Load(object sender, EventArgs e)
        {
            var results = GetThem().Result;
        }
        private async Task<Tuple<Cat,Dog,Pig>> GetThem()
        {
            Task<Cat> catAsync = GetCatAsync();
            Task<Dog> dogAsync = GetDogAsync();
            Task<Pig> pigAsync = GetPigAsync();
            await Task.WhenAll(catAsync, dogAsync, pigAsync).ConfigureAwait(false);
            //better yet,
            //   Task.WaitAll(catAsync, dogAsync, pigAsync);
            var cat = catAsync.Result;
            var dog = dogAsync.Result;
            var pig = pigAsync.Result;
            return Tuple.Create(cat, dog, pig);
        }
        private async Task<Pig> GetPigAsync()
        {
            var cat = new Pig();
            var res = await GetGoogleSearchHTML("cat").ConfigureAwait(false);
            using (StreamReader sr = new StreamReader(res.GetResponseStream()))
            {
                cat.Name = await sr.ReadToEndAsync().ConfigureAwait(false);
            }
            return cat;
        }
        public async Task<WebResponse> GetGoogleSearchHTML(string type)
        {
            System.Net.WebRequest request = System.Net.HttpWebRequest.Create(String.Format("http://www.google.com/search?noj=1&site=cat&source=hp&q={0}&oq=search", type));
            System.Net.WebResponse response = await request.GetResponseAsync().ConfigureAwait(false);
            return response;
        }
