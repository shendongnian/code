    class MasterTrack
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    class DbMasterTrack
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public static implicit operator MasterTrack(DbMasterTrack @this)
        {
            return new MasterTrack { Id = @this.Id, Name = @this.Name };
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var tracks = new List<DbMasterTrack>
            {
                new DbMasterTrack { Id = 1, Name = "T1" },
                new DbMasterTrack { Id = 2, Name = "T2" },
            };
    
            Func<MasterTrack, bool> query = t => t.Id == 1;
    
            var result = tracks.Where((Func<DbMasterTrack, bool>)(t => query(t)));
    
            foreach (var item in result)
            {
                Console.WriteLine("{0}|{1}", item.Id, item.Name);
            }
        }
    }
