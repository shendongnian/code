    Action<GrafBase> setVisibleIfNotNull = delegate(GrafBase graf)
    {
        if (graf != null)
            graf.IsVisible = true;
    };
    setVisibleIfNotNull(item.Graf);
    setVisibleIfNotNull(item.GrafReal);
    setVisibleIfNotNull(item.GrafIm);
