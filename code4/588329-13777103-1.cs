    for(int intCount=0;intCount<dgv.Rows.Count;intCount++)
    {
       if(intCount % 2 == 0)  //Your own condition here
       {
          DataGridViewComboBoxCell cmb = new DataGridViewComboBoxCell();
          //cmb.Value   // assign values in the combobox
          dgv[0,intCount] = cmb;
       }
       else
       {
          DataGridViewTextBoxCell txt = new DataGridViewTextBoxCell();
          txt.Value = "n/a";
          dgv[0,intCount] = txt;
       }
    }
