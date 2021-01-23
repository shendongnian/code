    class Program
    {
        static void Main(string[] args)
        {
            List<String> RadioNames = new List<String>();
            RadioNames.AddRange(new String[] { "abc", "123", "cba", "321" });
            List<ChannelGrants> grants = new List<ChannelGrants>();
            grants.Add(new ChannelGrants() { ID = 1, Radio = "cbaKentucky", RadioID = 1, TimeStamp = DateTime.Now });
            var result = from cg in grants
                      where RadioNames.Where(rn=>cg.Radio.ToLower().Contains(rn.ToLower())).Count() > 0
                      select cg;
            foreach (ChannelGrants s in result)
            {
                Console.WriteLine(s.Radio);
            }
        }
    }
    class ChannelGrants
    {
        public int ID { get; set; }
        public DateTime TimeStamp { get; set; }
        public int RadioID { get; set; }
        public string Radio { get; set; }
    }
