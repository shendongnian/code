        const string sonnetsShakespeare = @"http://www.gutenberg.org/cache/epub/1041/pg1041.txt";
        public async Task<IEnumerable<string>> Fetch(CancellationToken token)
        {
            string bookShakespeareSonnets = null;
            using (var downloader = new HttpClient())
            {
                var downloadTask = downloader.GetStringAsync(sonnetsShakespeare);
                // wait until downloadTask finished, but regularly check if cancellation requested:
                while (!downloadTask.Wait(TimeSpan.FromSeconds(0.2)))
                {
                    token.ThrowIfCancellationRequested();
                }
                // if still here: downloadTask completed
                bookShakespeareSonnets = downloadTask.Result;
            }
			
            // just for fun: find a nice sonnet, remove the beginning, split into lines and return 12 lines
            var indexNiceSonnet = bookShakespeareSonnets.IndexOf("Shall I compare thee to a summer's day?");
            return bookShakespeareSonnets.Remove(0, indexNiceSonnet)
                .Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                .Take(12);	
        }
    }
