    public void CheckApplicationNo(string TableName,string BranchNo)
        {
            try
            {
                var appno = (from app in dt.sys_Keys
                             where app.TableName == TableName && app.BranchNo.ToString() == BranchNo
                             select app.NewValue).SingleOrDefault();
                if(appno == null)
                    InsertApplicationNo();
                else
                {
                    Global.ApplicationNo = appno.ToString();
                    UpdateApplicationNo("Data_Customer_Log", Global.BranchNo);
                }
        }
        catch (Exception ex)
        {
             
        }
    }
