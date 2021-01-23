    void CheckBoxList1_SelectedIndexChanged(Object sender, EventArgs e) 
          {
    
             for (int i=0; i<checkboxlist1.Items.Count; i++)
             {
    
                if (checkboxlist1.Items[i].Selected)
                {
    
                   string value = checkboxlist1.Items[i].Text;
    
                }
    
             }
    
          }
