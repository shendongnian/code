    private async void _HttpServerDemo()
    {
        var info1 = _GetHttpWithTimingInfo("http://google.com");
        var info2 = _GetHttpWithTimingInfo("http://stackoverflow.com");
        var info3 = _GetHttpWithTimingInfo("http://twitter.com");
        await Task.WhenAll(info1, info2, info3);
        Console.WriteLine("Request1 took {0}", info1.Result);
        Console.WriteLine("Request2 took {0}", info2.Result);
        Console.WriteLine("Request3 took {0}", info3.Result);
    }
    private async Task<Tuple<HttpResponseMessage, TimeSpan>> _GetHttpWithTimingInfo(string url)
    {
        var stopWatch = new Stopwatch();
        stopWatch.Start();
        var result = await new HttpClient().GetAsync("http://google.com");
        return new Tuple<HttpResponseMessage, TimeSpan>(result, stopWatch.Elapsed);
    }
