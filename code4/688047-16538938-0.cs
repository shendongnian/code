     public IEnumerable<SubjectInfo> SubjectViewDetails(decimal decsubjectid)
    {
        var list = new List<SubjectInfo>();
        
        try
        {
            if (sqlcon.State == ConnectionState.Closed)
            {
                sqlcon.Open();
            }
            SqlCommand sqlcmd = new SqlCommand("SubjectView", sqlcon);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.Parameters.Add("@subjectId", SqlDbType.Decimal).Value = decsubjectid;
            using (var sqlreader = sqlcmd.ExecuteReader())
            {
                while (sqlreader.Read())
                {
                    SubjectInfo infosubject = new SubjectInfo();
                    infosubject.subjectId = decimal.Parse(sqlreader["subjectId"].ToString());
                    infosubject.subjectName = sqlreader["subjectName"].ToString();
                    infosubject.shortName = sqlreader["shortName"].ToString();
                    list.Add(infosubject);
                }
            }
        }
        catch
        {
            throw;
        }
        finally
        {
            sqlcon.Close();
        }
    
        return list;
    }
