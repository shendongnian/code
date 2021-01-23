        [Test]
        public void YieldResponse()
        {
            IEnumerable<Task<HttpResponseMessage>> responses = new ThreadedHttpGetter().GetResponses(Enumerable.Repeat(uri, iterations));
            Console.WriteLine(responses.Count());
        }
