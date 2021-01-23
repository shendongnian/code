    //Sample DataTable
    DataTable dt = new DataTable();
    dt.Columns.Add("IntCol");
    dt.Columns.Add("StrCol");
    dt.Rows.Add(new object[]{1,"1"});
    dt.Rows.Add(new object[]{2,"2"});
    var jsonstr = JsonConvert.SerializeObject(dt);
    var list = JsonConvert.DeserializeObject<List<YourClass>>(jsonstr);
    public class YourClass
    {
        public int IntCol { set; get; }
        public string StrCol { set; get; }
    }
