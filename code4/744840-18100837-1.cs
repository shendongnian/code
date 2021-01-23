               foreach (RepeaterItem item in RptLeaveRequests.Items)
               { 
                    var rdbList = item.FindControl("rbtVerified") as RadioButtonList;
                    switch(rdbList.SelectedValue)
                         {
                          case "1":
                            //Accept
                          break;
                          case "2":
                           //Reject
                          break;
                         }
               }
