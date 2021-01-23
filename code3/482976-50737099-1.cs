    using (SqlConnection cn = new SqlConnection(connectionString))
      {
        try
        {
          cn.Open();
          FileInfo file = new FileInfo(fileName);
          string script = file.OpenText().ReadToEnd();
          string[] splitChar = { "\r\nGO\r\n" };
          var sqlLines = script.Split(splitChar, StringSplitOptions.RemoveEmptyEntries);
          int res = 0;
          SqlCommand cmd = null;
          foreach (var query in sqlLines)
          {
              cmd = new SqlCommand(query, cn)
              {
                  CommandTimeout = 5400
              };
              res = cmd.ExecuteNonQuery();
          }
          cn.Close();
        }
        catch (Exception ex)
        {
          msg = ex.Message;
        }
        finally
        {
          cn.Close();
        }
      }
