    public class Calendar
    {
        public Calendar() { }
        public Calendar(int id, string title)
        {
           Id = id;
           Title = title;
        }
        public int Id { get; set; }
        public string Title { get; set; }
    }
    
    public class CalendarService
    {
        public static List<Calendar> GetAll()
        {
            var list = new List<Calendar>();
    
            var db = new mssql2();
            db.set("s1");
            string sql = @"select * from [cal]";
            var dr = db.dr(sql);
            while (dr.Read())
            {
                // Use the constructor to create a new Calendar item
                list.Add(new Calendar((int)dr["id"], dr["title"].ToString()));
            }
            return list;
        }
    }
