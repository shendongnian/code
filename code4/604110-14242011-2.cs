    ArrayList list =  ViewState["PREV"] as ArrayList;
    for (int i = 0; i < checkBoxList1.Items.Count; i++)
    {
         if (checkBoxList1.Items[i].Selected == true && Convert.ToBoolean(list[i]) == false)
           {
               // Subscribe Method
           }   
         if (checkBoxList1.Items[i].Selected == false && Convert.ToBoolean(list[i]) == true)       
           {
               // Unsubscribe Method
           }
         else
           {
               // Continue to loop
           } 
    }
