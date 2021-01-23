    container.Register<ILower, Lower>();
    container.Register<IUpper, Upper>();
    container.RegisterInitializer<Upper>(upper =>
    {
        var lower = (Lower)container.GetInstance<ILower>();
        lower.SetCallback(upper);
        upper.Lower = lower;
    });
