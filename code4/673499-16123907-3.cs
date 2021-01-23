    string[] items={"Dhaka", "Chittagong", "Sylhet", "Cox'sbazar"};
    protected void fromSelected(object sender, EventArgs e)
    {
    
     if((sender as DropDownList)!=null)
      {
       DepartTo.Items.Clear();
       foreach(string str in items)
        {
           if((sender as DropDownList).SelectedItem.ToString()!=str)
           {
            DepartTo.Items.Add(str);
           }
         }
       }
    
    }
