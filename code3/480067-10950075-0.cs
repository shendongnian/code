    int EmailID = rdr.GetOrdinal("EmailID");
    Then when using GetString:
    if (!(rdr.IsDBNull(14)))
    {
         EmpNewData.SelectSingleNode("/my:myFields/my:Emp/my:EmpData/my:email", NamespaceManager).SetValue(rdr.GetString(EmailID));
    }
    else
    {
         EmpNewData.SelectSingleNode("/my:myFields/my:Emp/my:EmpData/my:email", NamespaceManager).SetValue("No Email");
    }
