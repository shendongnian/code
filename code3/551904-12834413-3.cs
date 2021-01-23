    private List<MyObj> test(DataTable dt)
        {
           
            var convertedList = (from rw in dt.AsEnumerable()
                       select new MyObj()
                       {
                           ID = Convert.ToInt32(rw["ID"]),
                           Name = Convert.ToString(rw["Name"])
                       }).ToList();
            return convertedList;
        }
