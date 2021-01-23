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
