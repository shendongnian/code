         if (!string.IsNullOrEmpty(disCode))
          {
                 selectQuery.Append("DISCOUNTCode = '" + disCode + "'");
          }
          if (!string.IsNullOrEmpty(disName))
          {
                 selectQuery.Append(" OR DISCOUNTName = '" + disName + "'");
          }
