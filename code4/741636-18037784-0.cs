     public bool find(string usernameid)
      {
          string query = String.Format("SELECT id FROM Users WHERE UserName='{0}'", usernameid);
          DataTable tbl = SeectData(query);
          if (tbl.Rows.Count == 0)
              return false;
          else
          {
              this.id = tbl.Rows[0][0].ToString();
              
              return true;
          }
    
      }
