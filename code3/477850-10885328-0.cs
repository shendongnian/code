    public bool IsUpdated { get; private set; }
    public bool IsDataUpdated()
    { 
         DataTable dtResults = mclsSQLServerTool.LoadDataTable("exec stp_RL_SEL_NameIsUpdated '" + mstrName + "'"); 
         IsUpdated = Convert.ToBoolean(dtResults.Rows[0]["RU_bitIsUpdated"]); 
 
         return IsUpdated; 
    } 
