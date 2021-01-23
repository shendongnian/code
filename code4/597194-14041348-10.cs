    try
    {
        cmd1.CommandText ="SELECT treatment FROM appointment WHERE patientid=@patientID";
        cmd1.Parameters.AddWithValue("@patientID", this.DropDownList1.SelectedValue);
        conn.Open();
        SqlDataReader dr = cmd1.ExecuteReader();
        while (dr.Read())
        {
            int PatientID = int.Parse(dr["treatment"]);
        }
        reader.Close();
        ((IDisposable)reader).Dispose();//always good idea to do proper cleanup
    }
    catch (Exception exc)
    {
        Response.Write(exc.ToString());
    }
