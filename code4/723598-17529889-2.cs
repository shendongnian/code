        public class DeviceLogData
        {
            private static SortedDictionary<DateTime, string> sorteditems = new SortedDictionary<DateTime, string>();
          
            public int DeviceID { get; set; }
            public int DeviceMode { get; set; }
            public DateTime Time { get; set; }
    
            public DeviceLogData(int id,int mode,DateTime dt)
            {
                DeviceID = id;
                DeviceMode = mode;
                Time = dt;
                sorteditems.Add(dt, string.Format("At {0} Device with Id -> {1} and mode -> {2} has logged!", dt, id, mode));
            }
    
            public static SortedDictionary<DateTime, string> GetRecords()
            {
                return sorteditems;
            }
        }
          
