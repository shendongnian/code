     var oPerfCounter = new PerformanceCounter();
    oPerfCounter.CategoryName = "Process";
    oPerfCounter.CounterName = "Virtual Bytes";
    oPerfCounter.InstanceName = "aspnet_wp";
    txtMemorysUsed.Text = "Virtual Bytes: " + oPerfCounter.RawValue + " bytes";
