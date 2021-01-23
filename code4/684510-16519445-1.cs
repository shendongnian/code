     public string GetSmallestPosting(string p)
          {
             List<int> numbers = new List<int>();
              if (index != null)
              {
                  int count = 0;
                  foreach (KeyValuePair<string, List<string>> pair in index)
                  {
                      foreach (string v in pair.Value)
                      {
                          count++;
                      }
                      numbers.Add(count);
                  }
                  return numbers.Min().ToString();
              }
              return null;
          }
         public string GetLongestPosting(string p)
          {
              List<int> numbers = new List<int>();
              if (index != null)
              {
                  int count = 0;
                  foreach (KeyValuePair<string, List<string>> pair in index)
                  {
                      foreach (string v in pair.Value)
                      {
                          count++;
                      }
                      numbers.Add(count);
                  }
                  return numbers.Max().ToString();
              }
              return null;
          }
