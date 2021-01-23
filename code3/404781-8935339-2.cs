    Temp temp = new Temp();
    var result = assistant.Execute<MySvcRef.UserClass[]>(()=>temp.GetAllUsers(client, pageIndex, pageSize),client.InnerChannel);
    int totalRecords = temp.TotalRecords;
    ...
    class Temp
    {
        public int TotalRecords;
        public MySvcRef.UserClass[] GetAllUsers(MySvcClient client, int pageIndex, int pageSize)
        { 
            int totalRecords;
            var result = client.GetAllUsers(out totalRecords, pageIndex, pageSize);
            TotalRecords = totalRecords;
            return result;
        }
    }  
