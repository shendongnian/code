    private GrabFrame_CallbackEx callback;
    public void Start()
    {
        // Start grabbing frames
        isGrabRunning = true;
        callback = new GrabFrame_CallbackEx(GrabCallback);
        StartGrabEx(callback);
    }
