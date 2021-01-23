    List<string> aEmailList = List<string>();
    foreach (DataRow rRow in GetUserReportsToChain.Rows)
    {
        if (!String.IsNullOrEmpty(rRow["usrEmailAddress"].ToString()))
        {
            aEmailList.Add(rRow["usrEmailAddress"].ToString());
        }
    }
    string sEmailList = String.Join(",", aEmailList);
