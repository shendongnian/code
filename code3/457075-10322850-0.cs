    if(name!=null)
    {
       addStaffSql.InsertCommand = "insertNewMember";
       addStaffSql.InsertCommandType = SqlDataSourceCommandType.StoredProcedure;
       addStaffSql.InsertParameters.Add("@name", name);
       addStaffSql.InsertParameters.Add("@age", age);
       addStaffSql.Insert();
    }
    else
    {
      //Send message back to user that name is not filled properly !
    }
