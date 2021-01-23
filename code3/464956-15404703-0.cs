    if (nicToUse != null)
             {
                try
                {
                   nicToUse.OnPacketArrival -= OnPackectArrivalLive;
                   nicToUse.OnPacketArrival += OnPackectArrivalLive;
                   try
                   {
                      if (nicToUse.Started)
                         nicToUse.StopCapture();
                      if (nicToUse.Opened)
                         nicToUse.Close();
                   }
                   catch (Exception)
                   {
                      //no handling, just do it.
                   }
    
                   nicToUse.Open(OpenFlags.Promiscuous|OpenFlags.MaxResponsiveness,10);                 
  
                   nicToUse.Filter = "(ether[0:4] = 0x010CCD04)";
                   nicToUse.StartCapture();
                }
                catch (Exception ex)
                {
                   throw new Exception(Resources.SharpPCapPacketsProducer_Start_Error_while_starting_online_capture_, ex);
                }
             }
