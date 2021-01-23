    // DirectX example
    presentParams.SwapEffect = SwapEffect.Discard;
    presentParams.BackBufferCount = 1;
    presentParams.PresentationInterval = PresentInterval.One;
    device = new Device(...
    Application.Idle += new EventHandler(OnApplicationIdle);
    // More on this here : http://blogs.msdn.com/tmiller/archive/2005/05/05/415008.aspx
    internal void OnApplicationIdle(object sender, EventArgs e)
    {
        Msg msg = new Msg();
        while (true)
        {
            if (PeekMessage(out msg, IntPtr.Zero, 0, 0, 0))
                break;
        }
        // Clearing render
        // ...
        if (displayImage)
        {
            // Render image
            // ...
            renderTime = DateTime.now();
        }
        device.Present();
    }
