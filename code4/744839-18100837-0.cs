               foreach (RepeaterItem item in RptLeaveRequests.Items)
               { 
                    var rdbList = item.FindControl("rbtVerified") as RadioButtonList;
                    if(rdbList.SelectedValue == "1")
                         {
                          //Accept
                         }
                    else
                         {
                         //Reject
                         }
               }
