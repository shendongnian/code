    string sql2 = "Insert into tbDepartment ([Title], [Abbreviation]) values (@Desc, @DepCode)";
    
    string sqlDep = "Select [ID] from tbDepartment where Title = '" + gridView3.GetRowCellValue(i, gridView3.Columns[DepCode]).ToString() +"'" ;
    SqlCommand cmdDep = new SqlCommand(sql2, connection);
    SqlCommand cmdUser = new SqlCommand(sqlDep , connection);
    
    var id = cmdUser.ExecuteScalar() as int?;
    
    if (id == null) //nothing found
    {
       //add new
        cmdDep.Parameters.Add("@Desc", SqlDbType.VarChar,50);
        cmdDep.Parameters.Add("@DepCode", SqlDbType.VarChar, 50);
        cmdDep.Parameters["@Desc"].Value = Convert.ToString(gridView3.GetRowCellValue(i, gridView3.Columns[DepDesc]));
        cmdDep.Parameters["@DepCode"].Value = Convert.ToString(gridView3.GetRowCellValue(i, gridView3.Columns[DepCode]));
    }
    else
    {
       //edit
    }
