    var conds = new List<string> ();
         // here is the main thing where i am getting the error
          if (!string.IsNullOrEmpty(disCode))
          {
                 conds.Add("DISCOUNTCode = '" + disCode + "'");
          }
          if (!string.IsNullOrEmpty(disName))
          {
                 conds.Add("DISCOUNTName = '" + disName + "'");
          }
          if (startDate != "0001-01-01")
          {
                 conds.Add("StartDate = '" + startDate + "'");
          }
          if(endDate != "0001-01-01")
                 conds.Add("EndDate = '" + endDate + "'");
          
         selectQuery.Append(String.Join(" OR ",conds));
