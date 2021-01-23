    /// <summary>
        /// Can be used to process multiple URL's concurrently.
        /// </summary>
        public class ConcurrentUrlProcessor : SemaphoreSlim
        {
            private int initialCount;
            private int maxCount;
            private readonly HttpClient httpClient;
    
            /// <summary>
            /// Initializes a new instance of the <see cref="T:System.Threading.SemaphoreSlim" /> class, specifying the initial number of requests that can be granted concurrently.
            /// </summary>
            /// <param name="initialCount">The initial number of requests for the semaphore that can be granted concurrently.</param>
            public ConcurrentUrlProcessor(int initialCount)
                :base(initialCount)
            {
                this.initialCount = initialCount;
                this.maxCount = int.MaxValue;
                this.httpClient = new HttpClient();
            }
            /// <summary>
            /// Initializes a new instance of the <see cref="T:System.Threading.SemaphoreSlim" /> class, specifying the initial and maximum number of requests that can be granted concurrently.
            /// </summary>
            /// <param name="initialCount">The initial number of requests for the semaphore that can be granted concurrently.</param>
            /// <param name="maxCount">The maximum number of requests for the semaphore that can be granted concurrently.</param>
            public ConcurrentUrlProcessor(int initialCount, int maxCount)
                : base(initialCount, maxCount) 
            {
                this.initialCount = initialCount;
                this.maxCount = maxCount;
                this.httpClient = new HttpClient();
            }
            /// <summary>
            /// Starts the processing.
            /// </summary>
            /// <param name="urls">The urls.</param>
            /// <returns>Task{IEnumerable{XDocument}}.</returns>
            public virtual async Task<IEnumerable<XDocument>> StartProcessing(params string[] urls)
            {
                List<Task> tasks = new List<Task>();
                List<XDocument> documents = new List<XDocument>();
    
                SemaphoreSlim throttler = new SemaphoreSlim(initialCount, maxCount);
                foreach (string url in urls)
                {
                    await throttler.WaitAsync();
    
                    tasks.Add(Task.Run(async () =>
                    {
                        try
                        {
                            string xml = await this.httpClient.GetStringAsync(url);
    
                            //move on to the next page if no xml is returned.
                            if (string.IsNullOrWhiteSpace(xml))
                                return;
    
                            var document = XDocument.Parse(xml);
                            documents.Add(document);
                        }
                        catch (Exception)
                        {
                            //TODO: log the error or do something with it.
                        }
                        finally
                        {
                            throttler.Release();
                        }
                    }));
                }
    
                await Task.WhenAll(tasks);
    
                return documents;
            }
        }
