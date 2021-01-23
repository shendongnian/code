    public static aClassCollection GetAssignedSubjectsByFacultyIdAndSemester(int facultyId, string semester)
    {
    var newClassCollection = new aClassCollection();
        using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlConn"].ConnectionString))
        {
            using (var command = new SqlCommand("pr_GetAssignedSubjectsByFacultyIdAndSemester", connection))
            {
                try
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@facultyId", facultyId);
                    command.Parameters.AddWithValue("@semester", semester);
                    connection.Open();
                    SqlDataReader dr = command.ExecuteReader();
                    while (dr.Read())
                    {
                        newClassCollection.Add(new Class(){vals = dr["vals"].ToString()});
                    }
                }
                catch (SqlException sqlEx)
                {
                 //at the very least log the error
                }
                finally
                {
                 //This isn't needed as we're using the USING statement which is deterministic                    finalisation, but I put it here (in this answer) to explain the Using...
                    connection.Close();
                }
            }
        }
    
        return newClassCollection;
    }
