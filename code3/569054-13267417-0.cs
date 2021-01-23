    protected void cbGV_CheckedChanged(object sender, EventArgs e)
        {
            //gets the current checked checkbox.
            CheckBox activeCheckBox = sender as CheckBox;
            BOOL flag = false;
            CheckBox selectedCheckBox;
            foreach (GridViewRow gvr in GridView1.Rows)
            {
                //this code is for finding the checkboxes in the gridview.
    
                CheckBox checkBox = ((CheckBox)gvr.FindControl("cbGV"));
                
                if (checkBox.Checked==true && flag==false)
                     {
                        flag = true;
                        selectedCheckBox = checkBox;
                     }
                 else
                     {
                         if (checkBox != selectedCheckBox)
                              {
                              checkBox.Enabled = false;
                              checkBox.Checked = false;
                              }
                     }
                //so basically, right here i'm confused on how i should compare the if/else logic, how i should compare and disable every other checkbox if the current checkbox is checked. Any ideas gues?
    
            }
