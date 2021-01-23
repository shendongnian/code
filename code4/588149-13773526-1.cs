        [Fact]
        public void PostAString()
        {
            var client = new HttpClient();
            var content = new StringContent("Some text");
            var response = client.PostAsync("http://oak:9999/api/text", content).Result;
            Assert.Equal("Some text",response.Content.ReadAsStringAsync().Result);
        }
