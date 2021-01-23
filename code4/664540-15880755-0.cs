    public Color ColorBeingReturned(string TextFromBox)
    {
        return (Color)(typeof (Color)
                      .GetProperty(TextFromBox,
                           BindingFlags.Static|
                           BindingFlags.Public|
                           BindingFlags.GetProperty))
                      .GetValue(null, null);
    }
