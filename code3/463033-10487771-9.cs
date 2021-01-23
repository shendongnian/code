        static IList<MemoryStream> GetMemoryStreams(AmazonS3 s3, IEnumerable<GetObjectRequest> requests)
        {
            Task<MemoryStream>[] tasks = GetMemoryStreamsAsync(s3, requests);
            Task.WaitAll(tasks);
            var r = tasks.Select(t => t.Result).ToList();
            return r;            
        }
