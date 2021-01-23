    return client.GetTaskAsync(pageID + "/albums")
          .ContinueWith(
              task =>
              {
                  if (!task.IsFaulted)
                  {
                      dynamic result = task.Result;
                      foreach (dynamic album in result.data)
                      {
                          if (album["type"] == "wall")
                          {
                              return (string)album["id"].ToString();
                          }
                      }
                      return string.Empty;
                  }
                  else
                  {
                      throw new DataRetrievalException(
                          "Failed to retrieve wall album ID.", task.Exception.InnerException);
                  }
              });
