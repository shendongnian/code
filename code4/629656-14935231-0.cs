    IAMCrossbar Xbar = (IAMCrossbar)pNM8001AnalogXbar; 
    //hr = Xbar.CanRoute(1, 0); 
    hr = Xbar.Route(1, 0); 
    checkHR(hr, "Some NM8001AnalogXbar Problem"); //CONNECT NM8001 Analog TUNER and NM8001 Analog XBAR 
    hr = pGraph.ConnectDirect(
      GetPin(pNM8001AnalogTuner, "Analog Video"), 
      GetPin(pNM8001AnalogXbar, "0: Video Tuner In"), 
      null); 
    checkHR(hr, "Can't Connect NM8001AnalogTuner and NM8001AnalogXbar");
