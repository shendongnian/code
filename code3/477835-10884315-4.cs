    myDetectLines =
              (from myElements in config.Descendants("DetectLine")
               select new DetectLine()
               {
                  DetectLineParam1 = (string)myElements.Element("ModuleParam1"),
                  DetectLineParam2 = (string)myElements.Element("ModuleParam2"),
                  ...
    
                  Channels = (from channel in myElements.Element("Channels").Element("Channel")
                     select new Channel() {
                         ChannelParams = new ChannelParams() { ... = channel.Element("ChannelParams").Value }
                     }).ToList();
               }).ToList<DetectLine>();
