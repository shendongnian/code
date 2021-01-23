    public class VivaClass
    {
        public VivaClass()
        {
            StudentObJ = new StudentClass();
            StudentObJ.SetGetDGroupID = "";
            StudentObJ.SetGetDUserName = "";
            StudentObJ.SetGetDProjectName = "";
            StudentObJ.SetGetDCity = "";
            this.Date = "";
            this.Time = "";
            this.isMake = false;
        }
        public VivaClass(string date, string time, bool isMake, string Gid, string uName, string Prjct, string city)
        {
            StudentObJ = new StudentClass(Gid, uName, Prjct, city);
            this.Date = date;
            this.Time = time;
            this.isMake = isMake;
        }
        public VivaClass(string date, string time, bool isMake, string uName,string city)
        {
            StudentObJ = new StudentClass();
            StudentObJ.UserName = uName;
            this.Date = date;
            this.Time = time;
            this.isMake = isMake;
            this.StudentObJ.SetGetDCity = city;
        }
    
        public StudentClass StudentObJ { get; set; }
    
        public int ID { get; set; }
    
        public string Date { get; set; }
    
        public string Time { get; set; }
    
        public bool IsMake { get; set; }
    
        public IEnumerable<VivaClass> VivaObj()
        {
            SqlConnection hookup = new SqlConnection(new ConnectionString().GetConString(("SqlConString")));
            string query = "Select ID,GroupID,StudentName,ProjectName,City,Date,Time,isMake FROM SchedualTB";
            SqlCommand cmd = new SqlCommand(query, hookup);
            hookup.Open();
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    VivaClass obj = new VivaClass();
                    obj.ID = Convert.ToInt32(dr["ID"]);
                    obj.StudentObJ.GroupID = Convert.ToString(dr["GroupID"]);
                    obj.StudentObJ.StudentName = Convert.ToString(dr["StudentName"]);
                    obj.StudentObJ.ProjectName = Convert.ToString(dr["ProjectName"]);
                    obj.StudentObJ.City = Convert.ToString(dr["City"]);
                    obj.Date = dr["Date"].ToString();
                    obj.Time = dr["Time"].ToString();
                    obj.IsMake = Convert.ToBoolean(dr["isMake"].ToString());
                    yield return obj;
                }
        }
    }
