      This may help you:
            you can use it in code behind file as well as inside the script tag
           
      enable AutoPostBack property of checkboxlist to true
       protected void CheckBoxList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i=0;            
            foreach (ListItem li in CheckBoxList1.Items)
            {
                if (li.Selected)
                    i++;
            }
            Response.Write(i);           
        }
