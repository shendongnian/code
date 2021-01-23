    DataTabel dtResult = dsResult.Tables[1].Clone();
    
    dtResult.Columns[1].DataType = Type.GetType("System.String");
    DataRow drEmpty = dtResult.NewRow();
    dsResult.Tables[1].Rows.InsertAt(drEmpty, 0);
    DataRow drBranch = dsResult.Tables[1].Rows[1];
    drBranch[1] = "Branch";
    dsResult.Tables[1].Rows.InsertAt(drBranch, 1);
