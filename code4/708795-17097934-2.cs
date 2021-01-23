    class Program
    {
        public class mList
        {
            public DateTime Ee { get; set; }
            public DateTime ndate { get; set; }
            public int SNo { get; set; }
            public int CId { get; set; }
            public int rID { get; set; }
        }
        static void Main(string[] args)
        {
            DataSet ds = new DataSet();
            DataTable t = new DataTable("Rows");
            t.Columns.Add("ee", typeof(DateTime));
            t.Columns.Add("ndate", typeof(DateTime));
            t.Columns.Add("sno", typeof(int));
            t.Columns.Add("cid", typeof(int));
            t.Columns.Add("rid", typeof(int));
            t.Rows.Add(DateTime.Now, DateTime.Now, 0, 1, null);
            t.Rows.Add(DateTime.Now, DateTime.Now, 2, 1, 2);
            t.Rows.Add(DateTime.Now, DateTime.Now, 4, 1, 1);
            t.Rows.Add(DateTime.Now, DateTime.Now, 5, 1, 1);
            ds.Tables.Add(t);
            //IF TABLE IS t0 - You get a null reference exception
            List<mList> newlist = ds.Tables["Rows"].AsEnumerable().Select(row => new mList
            {
                Ee = row.Field<DateTime?>(0).GetValueOrDefault(),
                ndate = row.Field<DateTime?>(1).GetValueOrDefault(),
                SNo = row.Field<int?>(2).GetValueOrDefault(),
                CId = row.Field<int?>(3).GetValueOrDefault(),
                rID = row.Field<int?>(4).GetValueOrDefault()
            }).ToList();
        }
    }
