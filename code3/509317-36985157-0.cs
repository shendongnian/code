    static int indexOfL=0;// the index of initial selected item
        protected void CheckBoxList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = 0;
            
            foreach (ListItem li in CheckBoxList1.Items)
            {    
                {
                    if (i != indexOfL && li.Selected)
                    {    
                        indexOfL=i;
                        CheckBoxList1.ClearSelection();
                        li.Selected = true;
                        
                    }
                    i++;
                }
            }}
