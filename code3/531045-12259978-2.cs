    public int lookUpDepart()
    {
        int idDepart = 0;
        using (SqlConnection con = new SqlConnection(conString))
        {
            string lookUpDepartmenId = "SELECT idDepartment FROM tbl_department WHERE department = " + department;
            con.Open();
            using (SqlCommand querylookUpDepartmenId = new SqlCommand(lookUpDepartmenId, openCon))
            {
                SqlDataReader read = querylookUpDepartmenId.ExecuteReader();
                while (read.Read())
                {
                    idDepart = Convert.ToInt32((read[0]).ToString());
                    break;
                }
            }
            con.Close();
            return idDepart;
        }
    }
