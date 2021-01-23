    public IBackgroundProcessor BackgroundProcessor { get; set; }
    public object Post(Item item)
    {
        BackgroundProcessor.Enqueue(
          new StaticProcessingTask(item, base.RequestContext.Files[0].InputStream));
        return new HttpResult("Processing started", 
            ContentType.PlainText + ContentType.Utf8Suffix);
    }
