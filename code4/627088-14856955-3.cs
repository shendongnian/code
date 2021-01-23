    string sql2 = "Insert into tbDepartment ([Title], [Abbreviation]) values (@Desc, @DepCode)";
    string sqlDep = "Select [ID] from tbDepartment where Title = @title" 
     
    SqlCommand cmdDep = new SqlCommand(sqlDep, connection);
    cmdDep.Parameters.AddWithValue("@title", gridView3.GetRowCellValue(i, gridView3.Columns[DepCode]).ToString();
    object result = cmdDep.ExecuteScalar();
    if(result != null)
    {
        cmdDep.Parameters.Clear();
        cmdDep.CommandText = sql2;
        cmdDep.Parameters.AddWithValue("@Desc", Convert.ToString(gridView3.GetRowCellValue(i, gridView3.Columns[DepDesc]);
        cmdDep.Parameters.AddWithValue("@DepCode", Convert.ToString(gridView3.GetRowCellValue(i, gridView3.Columns[DepCode]));
        cmdDep.ExecuteNonQuery();
    }
    else
        int id = Convert.ToInt32(result);
