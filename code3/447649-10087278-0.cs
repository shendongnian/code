		public static void WebCrawl(Func<string> getNextUrlToCrawl, // returns a URL or null if no more URLs 
			Action<string> crawlUrl, // action to crawl the URL 
			int pauseInMilli // if all threads engaged, waits for n milliseconds
			)
		{
			const int maxQueueLength = 50;
			string currentUrl = null;
			int queueLength = 0;
			while ((currentUrl = getNextUrlToCrawl()) != null)
			{
				string temp = currentUrl;
				if (queueLength < maxQueueLength)
				{
					Task.Factory.StartNew(() =>
						{
							Interlocked.Increment(ref queueLength);
							crawlUrl(temp);
						}
						).ContinueWith((t) => 
						{
							if(t.IsFaulted)
								Console.WriteLine(t.Exception.ToString());
							else
								Console.WriteLine("Successfully done!");
							Interlocked.Decrement(ref queueLength);
						}
						);
				}
				else
				{
					Thread.Sleep(pauseInMilli);
				}
			}
		}
