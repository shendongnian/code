    class PunchInfo
    {  
        public PunchInfo(DateTime time, int id)
        {
            Id = id;
            Time = time;
        }
        public DateTime Time;
        public int Id;
    }
    Dictionary<string, List<PunchInfo>> Devices;
    int Count = 0;
    const int Limit = 1000000;
    const int LowerLimit = 90 * Limit / 100;
    void SaveRecord(string device, int id, DateTime time)
    {
       PunchInfo info = new PunchInfo(time, id);
       List<PunchInfo> list;
       if (!Devices.TryGetValue(device, out list))
       {
          list = new List<PunchInfo>();
          Devices.Add(device, list);
       }
       list.Add(info);
       Count++;
       if (Count >= Limit)
       {
           List<string> writeDevices = new List<string>();
           foreach(KeyValuePair<string, List<PunchInfo>> item in Devices)
           {
               writeDevices.Add(item.Key);
               Count -= item.Value.Count;
               if (Count < LowerLimit) break;
           }
           foreach(string device in writeDevices)
           {
              List<PunchInfo> list = Devices[device];
              Devices.Remove(device);
              SaveDevices(device, list);
           }
        }
    }
    void SaveAllDevices()
    {
        foreach(KeyValuePair<string, List<PunchInfo>> item in Devices)
            SaveDevices(item.Key, item.Value);
        Devices.Clear();
    }
