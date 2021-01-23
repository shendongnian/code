     public string GetSmallestPosting(string p)
          {
              if (index != null)
              {
                return countor.Min().ToString();
              }
              return null;
          }
         public string GetLongestPosting(string p)
          {
              if (index != null)
              {
                  return countor.Max().ToString();
              }
              return null;
          }
