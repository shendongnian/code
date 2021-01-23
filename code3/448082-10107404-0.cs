    public class HwMemoryMap
    {
      private object lockobj = new object();
      volatile Dictionary<int, HwDataItem> HwCache;
    
      public void Set(HwDataItem dataItem)
      {
        lock (lockobj)
        {
          var copy = new Dictionary<int, HWDataItem>(HwCache);
          copy[dataItem.PtId] = dataItem;
          HwCache = copy;
        }
      }
    
      public List<HwDataItem> GetLatestValues()
      {
        var HwDataItemList = new List<HwDataItem>();
        // do work here to pull appropriate values out of HwCache
        HwDataItemList.Add(HwCache[0]); // etc
        return HwDataItemList;
      }
    }
