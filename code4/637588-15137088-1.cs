    public List<CandidateApplication> GetCandidateInformation()
            {
                DataTable dt = new DataTable();
    
                using (OleDbConnection con = new OleDbConnection(ConfigurationManager.AppSettings["con"]))
                {
                    using (OleDbCommand cmd = new OleDbCommand("SELECT * FROM [TableName]", con))
                    {
                        var adapter = new OleDbDataAdapter();
                        adapter.SelectCommand = cmd;
    
                        con.Open();
                        adapter.Fill(dt);
    
                        var CandApp = (from row in dt.AsEnumerable()
    
                        select new CandidateApplication
                        {
    
                        EmailID = row.Field<string>("EmailID"),
                        Name  = row.Field<string>("Name"),
                        PhoneNo = row.Field<string>("PhoneNo"),
                        CurrentLocation = row.Field<string>("CurrentLocation"),
                        PreferredWorkLocation = row.Field<string>("PreferredWorkLocation"),
                        RoleApplingFor = row.Field<int>("RoleApplingFor"),
                        CurrentJobTitle = row.Field<string>("CurrentJobTitle"),
                        EducationLevel = row.Field<int>("EducationLevel "),
                        SalaryExpected = row.Field<decimal>("SalaryExpected"),
                        AvailableTime = row.Field<string>("AvailableTime"),
                        AdvertID = row.Field<int>("AdvertID"),
                        SignForAlert = row.Field<bool>("SignForAlert"),
                        CVInText = row.Field<string>("CVInText"),
                        CVFileName = row.Field<string>("CVFileName"),
                        IsDownloaded = row.Field<bool>("IsDownloaded"),
                        Specialization = row.Field<string>("Specialization"),
                        Isallocated = row.Field<bool>("Isallocated"),
                        Id = row.Field<int>("Id"),
                        AdvertAdditionalInfo = row.Field<string>("AdvertAdditionalInfo")
                   
    
                        }).ToList();
    
                        return CandApp;
                    }
                }
            }
