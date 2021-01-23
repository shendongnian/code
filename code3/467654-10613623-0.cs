    foreach (DataTable element in strList)     
        {          
        if (element.Rows.Count>0)
            {
            if(strList.Any(item => item == null))          
                {                
              ConvertNullToEmptyStringelement);                                                 
                }
            txtItem1.Text = mytext ;          
            .....
            }
        else
            {
            txtItem1.Text = "No Data";          
            }      
        } 
