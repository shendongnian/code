    for (int ii = 0; ii < 28; ii++)
    {
       cb[ii] = new ComboBox();
       cb[ii].Name = "cb"+ii.ToString();
    
       cb[ii].Items.Add("OK");
       cb[ii].Items.Add("NOT OK");
    
       cb[ii].SelectedIndex = 0;        //"OK" option will be selected
       cb[ii].ForeColor = Color.Black;  //set forecolor to black
    
       cb[ii].SelectedIndexChanged += ComboBoxSelectedIndexChanged;  
    }
