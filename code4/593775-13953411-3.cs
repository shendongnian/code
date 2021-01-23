    public static void EnsureApplicationResources()
    {
        if (Application.Current == null)
        {
            // create the Application object
            new App();
        }
    }
