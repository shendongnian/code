    rotected DataSet GetStudentByProgramID(int programID)
    {
     DataColumn programId = ds1.Tables[0].Columns["ProgramId"];
    //to read row you can iterate from ds1.Table[0].Rows
    DataSet ds2 = new DataSet();
    using (SqlConnection cn = new SqlConnection("server=Daffodils-PC\\sqlexpress;Database=Assignment1;Trusted_Connection=Yes;"))
    {
    using (SqlDataAdapter da = new SqlDataAdapter(@"SELECT LastName, FirstName FROM Student WHERE ProgramID ="+programID, cn))
    da.Fill(ds2, "Student");
    }
    return ds2;
    }
