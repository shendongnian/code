    try
    {
    
    // initialize D3D device 
    PresentParameters presentParams = new PresentParameters();
    presentParams.Windowed = true;
    presentParams.SwapEffect = SwapEffect.Discard;
    Device myDevice = new
    Device(0,DeviceType.Hardware,this,CreateFlags.SoftwareVertexProcessing,presentParams);
    
    // create a surface the size of screen, 
    // format had to be A8R8G8B8, as the GetFrontBufferData returns
    // only memory pool types allowed are Pool.Scratch or Pool.System memory
    Surface mySurface =
    myDevice.CreateOffscreenPlainSurface(SystemInformation.PrimaryMonitorSize.Width,SystemInformation.PrimaryMonitorSize.Height,Format.A8R8G8B8,Pool.SystemMemory);
    
    //Get the front buffer.
    myDevice.GetFrontBufferData(0,mySurface);
    
    //saves surface to file
    SurfaceLoader.Save("surface.bmp",ImageFileFormat.Bmp,mySurface);
    
    }
    catch
    {
       //whatever
    }
