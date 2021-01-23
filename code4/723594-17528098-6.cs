    public class DeviceLogData {
        public int DeviceID{get; set;}
        public int DeviceMode{get; set;}
        public DateTime Time {get; set;}
    }
    
    
---
    
    void Foo(){
    
        var theList = new List<DeviceLogData>();
        theList.Add(new DeviceLogData{
            DeviceID: 42,
            DeviceMode: 66,
            Time = DateTime.Now
        });
    
        ...
        var ordered = theList.OrderBy(log=>log.Time);
        foreach(var log in ordered)
        {
              DoSomethingWithLog(log);
        }
    }
