            var urls = new[]
	        {
		        "http://stackoverflow.com/questions/10693617/"
                                    + "rx-framework-for-a-web-crawler",
		        "http://stackoverflow.com/",
		        "http://stackoverflow.com/users/259769/enigmativity",
	        };
            ServicePointManager.DefaultConnectionLimit = 100;
            Func<string, IObservable<WebResponse>> getResponse =
                url =>
                    Observable.Defer(() =>
                    {
                        var wr = WebRequest.Create(url);
                        return
                            Observable
                                .FromAsyncPattern<WebResponse>(
                                    wr.BeginGetResponse,
                                    wr.EndGetResponse).Invoke();
                    });
            var query =
                from u in urls.ToObservable()
                from r in getResponse(u)
                select r.ContentLength;
            
            query.Subscribe(x => Console.WriteLine(x));
