    protected override void Write(LogEventInfo logEvent)
    {
        if (logEvent.Level >= LogLevel.Error)
        {
            Trace.Fail(this.Layout.Render(logEvent));
        }
        else
        {
            Trace.WriteLine(this.Layout.Render(logEvent));
        }
    }
