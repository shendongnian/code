    using(SqlConnection conn = new SqlConnection(connString))
    {
       for(int i=0; i < urlList.Length; i++)
       {
          string url   = urlList[i];
          string title = titleList[i];
          SqlCommand cmd = new SQlCommand({insert sql here});
          cmd.ExecuteNonQuery();
       }
    }
