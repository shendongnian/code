    List<VoltageChannel> AvailableChannels {
      get
      {
         var returned = new List<VoltageChannel>();
         foreach (VoltageChannel vc in VoltageChannelList)
         {
            if (vc.IsAvailable)
              returned.add(vc);
         }
         return vc;
      }
    }
