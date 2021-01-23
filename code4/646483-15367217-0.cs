    DataSet FooDS = new DataSet();   // <-- FooDS?
    OleDbCon.Open();
    OleDbAdpt.Fill(ExpediteDS);   // <-- filing a different dataset?
    OleDbCon.Close();
    OleDbCon.Dispose();
    DataTable EmployeeInfo = FooDS.Tables[0];  // <-- not the dataset you just filled!
