    //global scope
    Color c = Color.Black
    PresentParameters parameters = new PresentParameters();
    parameters.Windowed = true;
    parameters.SwapEffect = SwapEffect.Discard;
    Device d = new Device(0, DeviceType.Hardware, hWnd, CreateFlags.HardwareVertexProcessing, parameters);
    Surface s = d.CreateOffscreenPlainSurface(Manager.Adapters.Default.CurrentDisplayMode.Width,  Manager.Adapters.Default.CurrentDisplayMode.Height, Format.A8R8G8B8,
                                                  Pool.Scratch);
    
    //method to test
    d.GetFrontBufferData(0, s);
    
    GraphicsStream gs = s.LockRectangle(LockFlags.None);
    byte[] bu = new byte[4];
    gs.Position = readPos;
    gs.Read(bu, 0, 4);
    int r = bu[2];
    int g = bu[1];
    int b = bu[0];
    c = return Color.FromArgb(r, g, b);
     
    s.UnlockRectangle();
    s.ReleaseGraphics();
