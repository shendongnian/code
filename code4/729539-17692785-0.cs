    IGraphBuilder graphBuilder = new FilterGraph() as IGraphBuilder;
    DsDevice device = DsDevice.GetDevicesOfCat(FilterCategory.VideoInputDevice)[1]; // <<--- Your Device
    Guid baseFilterIdentifier = typeof(IBaseFilter).GUID;
    object videoSourceObject;
    device.Mon.BindToObject(null, null, ref baseFilterIdentifier, out videoSourceObject);
    IBaseFilter videoSourceBaseFilter = videoSourceObject as IBaseFilter;
    graphBuilder.AddFilter(videoSourceBaseFilter, "Source");
    ICaptureGraphBuilder2 captureGraphBuilder = new CaptureGraphBuilder2() as ICaptureGraphBuilder2;
    captureGraphBuilder.SetFiltergraph(graphBuilder);
    object crossbarObject;
    captureGraphBuilder.FindInterface(FindDirection.UpstreamOnly, null, videoSourceBaseFilter, typeof(IAMCrossbar).GUID, out crossbarObject);
    IAMCrossbar crossbar = crossbarObject as IAMCrossbar;
    int inputPinCount, outputPinCount;
    crossbar.get_PinCounts(out inputPinCount, out outputPinCount); // <<-- In/Out Pins
    // Pin Selection: Physical Input 2 (e.g. Composite) to Capture Pin 0 
    crossbar.Route(0, 2);
