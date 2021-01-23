    foreach (ListViewItem item in lvTest.Items) 
    {
        if(item.SubItems[1].Text == "OK") 
            item.BackColor = System.Drawing.Color.Green;
        else 
            item.BackColor = System.Drawing.Color.Red;
    }
