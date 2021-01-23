    [HttpPost]
    public HttpResponseMessage DoWork(MyModel model)
    {
       // Do work
       return new HttpResponseMessage(HttpStatusCode.OK) { Content = new ObjectContent<MyModel>(model, FormatterConfig.JsonFormatter) };
    }
