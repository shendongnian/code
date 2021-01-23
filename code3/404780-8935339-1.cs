    var client = MySvcRef.MySvcClient();
    var assistant = FormsAuthenticationAssistant();
    var totalRecords;
    var result = assistant.Execute<MySvcRef.UserClass[]>(
      ()=>client.GetAllUsers(out totalRecords, pageIndex, pageSize), 
      client.InnerChannel);
