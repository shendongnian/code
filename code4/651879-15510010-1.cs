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
       if (Count >= 1000000)
       {
           List<string> writeDevices = new List<string>();
           foreach(KeyValuePair<string, List<PunchInfo>> item in Devices)
           {
               writeDevices.Add(item.Key);
               Count -= item.Value.Count;
               if (Count < 900000) break;
           }
           foreach(string device in writeDevices)
           {
              List<PunchInfo> list = Devices[device];
              Devices.Remove(device);
              SaveDevices(device, list);
           }
        }
    }
