    ListView lv = new ListView()
    TreeView tv = new TreeView()
    ListBox lb = new ListBox()
    
    
        for(int i=0;i<int.MAXVALUE;i++)
        {
        lv.Items.Add(i);
        }
        
        for(int i=0;i<int.MAXVALUE;i++)
        {
        tv.Nodes.Add(i);
        }
        
        
        for(int i=0;i<int.MAXVALUE;i++)
        {
        lb.Items.Add(i);
        }
    
    
    private void btnButton_Click(object sender, EventArgs e)
            {
    
    MessageBox.Show(lv.SelectedItems[0].ToString());
    MessageBox.Show(tv.SelectedNode.ToString());
    MessageBox.Show(lb.SelectedItem.ToString());
    }
