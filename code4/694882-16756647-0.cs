    private void myToolStripMenuItem_Click(object sender, EventArgs e)
            {
                // source menu item which was clicked
                ToolStripMenuItem item = sender as ToolStripMenuItem;
    
                if(item != null) 
                {
                    int index = int.Parse(item.Tag.ToString()); // get the index from Tag
                    myObject control = myObjectList[index];
    
                    // do your stuff with your control
    
                }
            } 
