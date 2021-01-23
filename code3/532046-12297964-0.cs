    if (MyAppender.IsWarnEnabled)
    {
        MyAppender.Warn(String.Format("Some warning message! A:{0}, B:{1}, C:{2}, D:{3}", 0, 1, 2, 3));
    }
...
    if (MyAppender.IsDebugEnabled)
    {
        MyAppender.Debug(String.Format("Some debug info! A:{0}, B:{1}, C:{2}, D:{3}", 0, 1, 2, 3));
    }
