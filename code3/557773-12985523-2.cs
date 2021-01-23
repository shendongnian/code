    public class VivaClass
    {
        public VivaClass()
        {
            StudentObJ = new StudentClass();
            StudentObJ.GroupID = "";
            StudentObJ.UserName = "";
            StudentObJ.ProjectName = "";
            StudentObJ.City = "";
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
        public VivaClass(string date, string time, bool isMake, string name, string city)
        {
            Student = new StudentClass();
            Student.UserName = name;
            Student.City = city;
            Date = date;
            Time = time;
            IsMake = isMake;
        }
    
        public StudentClass Student { get; set; }
    
        public int ID { get; set; }
    
        public string Date { get; set; }
    
        public string Time { get; set; }
    
        public bool IsMake { get; set; }
    
        public IEnumerable<VivaClass> Vivas()
        {
            using (SqlConnection connection = new SqlConnection(new ConnectionString().GetConString(("SqlConString"))))
            {
                string query = "Select ID,GroupID,StudentName,ProjectName,City,Date,Time,isMake FROM SchedualTB";
                SqlCommand cmd = new SqlCommand(query, connection);
                connection.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        VivaClass obj = new VivaClass();
                        obj.ID = (int(dr["ID"];
                        obj.Student.GroupID = (string)dr["GroupID"];
                        obj.Student.StudentName = (string)dr["StudentName"];
                        obj.Student.ProjectName = (string)dr["ProjectName"];
                        obj.Student.City = (string)dr["City"];
                        obj.Date = (string)dr["Date"].ToString();
                        obj.Time = (string)dr["Time"];
                        obj.IsMake = (bool)dr["isMake"];
                        yield return obj;
                    }
                }
            }
        }    
    }
