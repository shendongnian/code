        DataTable FilingStatus = new DataTable("FilingStatus");
        SqlConnection sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["CentralW2Database"].ConnectionString); 
        sqlcon.Open();
        SqlCommand cmd = new SqlCommand("select CollectorGuid, FileStatus,FilingYear, ServiceLevel from dbo.FilingRequestQueue", sqlcon);
        using (var dr = cmd.ExecuteReader()) 
        {
           IList<FilingDto> list = LoadStatusDtofromReader(dr);
        }
        internal IList<FilingDto> LoadStatusDtofromReader(IDataReader reader)
        {
            var filingstatus = new List<FilingDto>();
            while (reader != null && reader.Read())
            {
                var dto = new FilingDto
                {
                    Controllerid = (Guid)reader["Collectorid"],
                    Status = DBNull.Value.Equals(reader["Status"]) ? string.Empty : reader["Status"].ToString(),
                    Year = Convert.ToInt32((Decimal)reader["Year"]),
                    Level = DBNull.Value.Equals(reader["Level"]) ? string.Empty : reader["ServiceLevel"].ToString()
                };
                filingstatus.Add(dto);
            }
            return filingstatus;
        }
