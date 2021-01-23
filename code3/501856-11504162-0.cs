          if (!string.IsNullOrEmpty(disCode))
          {
                 selectQuery.Append("DISCOUNTCode = '" + disCode + "'");
          }
          else
                 selectQuery.Append("0");
