    public void InsertExamWrittn(int writtnId, string cirname, DateTime publishingDate, string applicantId, string applicantname, string highestMrk, string writtnAchievMrk)
    {
    
        using (var con = new SqlConnection("Data Source=SERVER;Initial Catalog=HRPR;Persist Security Info=True;User ID=hr;Password=11"))
        using(var cmd= con.CreateCommand())
        {
            cmd.CommandText = "INSERT INTO tblExmWrittn (WrittnId, Cirname, publishingDate, ApplicantId, Applicantname, HighestMrk, WrittnAchievMrk) "+
                                "VALUES (@WrittnId, @Cirname, @publishingDate, @ApplicantId, @Applicantname, @HighestMrk, @WrittnAchievMrk)";
            cmd.Parameters.AddWithValue("@WrittnId", writtnId);
            cmd.Parameters.AddWithValue("@Cirname", cirname);
            cmd.Parameters.AddWithValue("@publishingDate", publishingDate);
            cmd.Parameters.AddWithValue("@ApplicantId", applicantId);
            cmd.Parameters.AddWithValue("@Applicantname", applicantname);
            cmd.Parameters.AddWithValue("@HighestMrk", highestMrk);
            cmd.Parameters.AddWithValue("@WrittnAchievMrk", writtnAchievMrk);
            con.Open();
            cmd.ExecuteNonQuery();
        }
    }
