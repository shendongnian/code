    private void PopulateCaseViewer(string paramField, string paramValue)
        {
            string strConnection = BuildConnectionString();
            SqlConnection linkToDB = new SqlConnection(strConnection);
    
            if (paramField == "load")
            {
                string sqlStat = "SELECT c.CaseNo, c.Claimant, c.Defendant, c.DOA, c.CaseType, c.CaseManager, c.Occupation, c.DateInstruction " +
                                 "a.IPName, a.IPRegion, l.IPReference " +
                                 "FROM tblCases AS c INNER JOIN tblIPLinks as l ON c.CaseNo = l.CaseNo " +
                                 "JOIN tblIPAddresses AS a ON l.IPID = a.IPID;";
            
              using (linkToDB)
              using (var adapter = new SqlDataAdapter(sqlStat, linkToDB))
              {
                var table = new DataTable();
                adapter.Fill(table);
                dataCaseViewer.DataSource = table;
              }
            }
        }
