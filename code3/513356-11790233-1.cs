       List<string> IssueList = new List<string>();
          for (int i = 0; i < dt.DataSet.Tables[0].Rows.Count; i++)
          {
             IssueList.Add(dt.DataSet.Tables[0].Rows[i][0].ToString());
         }
        return IssueList.ToArray();
