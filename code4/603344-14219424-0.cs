    foreach( ListItem item in ListBox1.Items){
        WebService1 ws = new WebService1();
        int flag = ws.callFlags(10, item.Text); // <- Changed to item.Text from item
        if (flag == 1)
        {
            ListBox1.Items.Remove(item);
        }
    }
