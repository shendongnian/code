    public class DeviceLogData {
        public int DeviceID{get; set;}
        public int DeviceMode{get; set;}
        public DateTime Time {get; set;}
    }
    
    
    ...
    
    void Foo(){
    
        var theList = new SortedList<DateTime, DeviceLogData>(val=>val.Time, val=>val);
        theList.Add(new DeviceLogData{
            DeviceID: 42,
            DeviceMode: 66,
            Time = DateTime.Now
        });
    
    }
