        for( int x = tabControl.Items.Count - 1; x>= 0; x--)
        {  
            TabItem item = tabControl.Items[x];
            if (nodeData.Text == item.Header.ToString())  
            {  
                item.Focus();  
            }  
            else if (nodeData.Text != item.Header.ToString())  
            {  
                SubGraphButton_Click(sender, args);  
            }  
        }  
