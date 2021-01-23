    DetectLine dl1 = new DetectLine() {
      DetectLineParams = ...,
      Channels = (from channel in detectLine.Element("Channels").Element("Channel")
                 select new Channel() {
                     ChannelParams = new ChannelParams() { ... = channel.Element("ChannelParams").Value }
                 }).ToList();
