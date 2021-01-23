    public class ReturnType
    {
        public int UpdateId { get; set; }
        public string WhateverString { get; set; }  
    }
    List<ReturnType> Update_Select_Result = null;
    Update_Select_Result = DB.Query(CMD_Select, Request["UpdateID"]);
