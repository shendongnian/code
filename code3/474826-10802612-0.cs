    foreach (DataRow dr in dt.Rows)                  
    {                       
         DateTime myDate;
         if(dr.IsNull("CompletedBy")) 
             myDate = DateTime.MinValue;
         else
         {
             if(DateTime.TryParse(dr["CompletedBy"].ToString(), out myDate) == false)
                 myDate = DateTime.MinValue;
         }
         wt = new WorkTasksDto                              
         {                                  
             CompletedBy = (myDate == DateTime.MinValue ? null : myDate);
         };         
    } 
