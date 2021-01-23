    private Regex _regex= new Regex("net");
    
            private void ProcessInParallell()
            {
               Uri[] resourceUri = new Uri[]{new Uri("http://www.microsoft.com"),new Uri( "http://www.google.com"),new Uri( "http://www.amazon.com") };
    
    
                //1. Stage 1: Download HTML
    
                //Use the blocking collection for concurrent tasks
                BlockingCollection<string> htmlDataList = new BlockingCollection<string>();
    
                Parallel.For(0, resourceUri.Length , index =>
                    {   var html = RetrieveHTML(resourceUri[index]);
    
                        htmlDataList.TryAdd(html);
    
                        //If we reach to the last index, signal the completion
                        if (index == (resourceUri.Length - 1))
                        {   
                            htmlDataList.CompleteAdding();
                        }
    
                    });
    
    
                //2. Get matches
    
                //This concurrent bags will be used to store the result of the matching stage
                ConcurrentBag<string> matchedHtml = new ConcurrentBag<string>();
    
                IList<Task> processingTasks  = new List<Task>();
    
                //Enumerate through each downloaded HTML document
                foreach (var html  in htmlDataList.GetConsumingEnumerable())
                {
                    //Create a new task to match the downloaded HTML
                  var task=   Task.Factory.StartNew((data) =>
                        {
                            var downloadedHtml = data as string;
                            if(downloadedHtml ==null)
                                return;
    
                            if (_regex.IsMatch(downloadedHtml))
                            {
                                
                                matchedHtml.Add(downloadedHtml);
                            }
    
                        }, 
                         html  
                        );
    
                    //Add the task to the waiting list
                    processingTasks.Add(task);
    
                }
    
                //wait for the all tasks to complete
                Task.WaitAll(processingTasks.ToArray());
    
    
                
                foreach (var html in matchedHtml)
                {
                    //Do something with the matched result    
                    
                }
              
    
    
    
            }
    
            private string  RetrieveHTML(Uri uri)
            {
               using (WebClient webClient = new WebClient())
               {
                   //set this to null if there is no proxy
                   webClient.Proxy = null;
    
                   byte[] data =webClient.DownloadData(uri);
    
                   return Encoding.UTF8.GetString(data);
               }
            }
