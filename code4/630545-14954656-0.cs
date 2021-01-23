    private TaskCompletionSource<double> currentFrameSource;
    // Called from game loop
    public void OnUpdate(double elapsedTime)
    {
        ...
        var previousFrameSource = currentFrameSource;
        currentFrameSource = new TaskCompletionSource<double>();
        // This will trigger all the continuations...
        previousFrameSource.SetResult(elapsedTime);
    }
    // Async method called by NPC "script"
    public async Task WalkTo(int x, int y)
    {
        // Store new target location
        while (/* we're not there yet */)
        {
            double currentTime = await currentFrameSource.Task;
            // Move
        }
    }
