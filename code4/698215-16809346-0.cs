    class Program
    {
        static void Main(string[] args)
        {
            List<DeviceLog> list = new List<DeviceLog>
                {
                    new DeviceLog() { Id = 1, UserId = 1, LogDate = DateTime.Parse("2013-05-29 11:05:15") },
                    new DeviceLog() { Id = 2, UserId = 1, LogDate = DateTime.Parse("2013-05-29 11:05:20") },
                    new DeviceLog() { Id = 3, UserId = 1, LogDate = DateTime.Parse("2013-05-29 11:07:56") },
                    new DeviceLog() { Id = 4, UserId = 1, LogDate = DateTime.Parse("2013-05-29 11:11:15") },
                    new DeviceLog() { Id = 5, UserId = 2, LogDate = DateTime.Parse("2013-05-29 11:06:05") },
                    new DeviceLog() { Id = 6, UserId = 2, LogDate = DateTime.Parse("2013-05-29 11:07:18") },
                    new DeviceLog() { Id = 7, UserId = 2, LogDate = DateTime.Parse("2013-05-29 11:09:38") },
                    new DeviceLog() { Id = 8, UserId = 2, LogDate = DateTime.Parse("2013-05-29 11:12:15") },
                };
            list = list.Where(l => (l.Id == list.Where(g => g.UserId == l.UserId).Min(h => h.Id))
                || (l.LogDate - list.Where(g => g.UserId == l.UserId).OrderBy(m => m.Id).First().LogDate).Minutes > 5 ).ToList();
        }
        
    }
    class DeviceLog
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime LogDate { get; set; }
    }
