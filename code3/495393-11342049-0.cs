   if (dtDetails.Rows.Count > 0)
            {
                foreach (DataRow dr in dtDetails.Rows)
                {
                    DateTime startingDate = Convert.ToDateTime( dr["fromdate"]);
                    DateTime endingDate = Convert.ToDateTime(dr["todate"]);
                    DateTime newdate;
                    for (newdate = startingDate; newdate <= endingDate; newdate = newdate.AddDays(1))
                    {
                      DataRow dr2 = dt2.NewRow();
                        dt2.Rows.Add(newdate);
                    }
                       
                }
            }
