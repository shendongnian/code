    void CheckBoxList1_SelectedIndexChanged(Object sender, EventArgs e) 
          { 
       foreach var item in CheckBoxList1.Items
        {
           if(item.Selected)
           {
             string value = item.Text;
             'DO SOMETHING
           }
        }
    }
