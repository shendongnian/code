    HttpListener listener = new HttpListener();
    listener.Prefixes.Add("http://*:8080/");
    listener.Start();
    while (true)
    {
        HttpListenerContext ctx = listener.GetContext();
        ThreadPool.QueueUserWorkItem((_) =>
        {
            string methodName = ctx.Request.Url.Segments[1].Replace("/", "");
            string[] strParams = ctx.Request.Url
                                    .Segments
                                    .Skip(2)
                                    .Select(s=>s.Replace("/",""))
                                    .ToArray();
            var method = this.GetType()
                                .GetMethods()
                                .Where(mi => mi.GetCustomAttributes(true).Any(attr => attr is Mapping && ((Mapping)attr).Map == methodName))
                                .First();
            object[] @params = method.GetParameters()
                                .Select((p, i) => Convert.ChangeType(strParams[i], p.ParameterType))
                                .ToArray();
            object ret = method.Invoke(this, @params);
            string retstr = JsonConvert.SerializeObject(ret);
        });
    }
