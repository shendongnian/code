    // in App.xaml.cs
    var ctx = ContextRegistry.GetContext();
    MainApplication mainApp = (MainApplication)ctx.GetObject("MainApp");
    
    // not needed; called by the spring container:
    // var data = (IMachineData)ctx.GetObject("MachineData");
    // data.Init();
    
    // ...
