    EventHandler<ReadingWritingEntityEventArgs> aDelegate = delegate(object sender, ReadingWritingEntityEventArgs e)
        {
        };
    _serviceContext.ReadingEntity += aDelegate;
    _serviceContext.ReadingEntity -= aDelegate;
