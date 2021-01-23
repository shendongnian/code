    int i; 
    // Substract 1 to eliminate last floor
    int cnt = Convert.ToInt32(tmpBox3.SelectedItem.Text) - 1; 
    tmpBox3.Items.Add(0, new ListItem("--Select--","0")); //add select 
 
    // Notice starting at 1 instead of 0
    for (i = 1; i <= cnt; i++) 
    { 
         tmpBox3.Items.Add(i, new ListItem(i.ToString(), i.ToString())); 
    } 
 
    tmpBox3.SelectedIndex = 0; // make select default choice 
