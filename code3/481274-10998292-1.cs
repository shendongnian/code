    void RenderLoop()
    {
        while(applicationActive)
        {
              device.BeginScene();
            // Other rendering task
            if (shouldDisplayImageEvent.WaitOne(0))
            {
                // Render image
                // ...
                userResponseStopwatch = new Stopwatch();
                userResponseStopwatch.Start();
            }
            device.EndScene();
            device.Present();
        }
    }
