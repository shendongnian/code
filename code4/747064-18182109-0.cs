    public static IObservable<bool> DownloadLink(this IObservable<Uri> source)
    {
        return Observable.Create<bool>(observer =>
        {
            return source
                .Subscribe(onNext: async link =>
                {
                    using (var client = new System.Net.Http.HttpClient())
                    {
                        var result = await client.GetStringAsync(link);
    
                        if (isSuccess)
                            observer.OnNext(true);
                        else
                            observer.OnNext(false);
                    }
                }, onError: observer.OnError, onCompleted: observer.OnCompleted);
        });
    }
