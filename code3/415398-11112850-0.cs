    this.ListBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.List_RightClick);
    
    private void List_RightClick(object sender, MouseEventArgs e)
            {
             
                if (e.Button == MouseButtons.Right)
                {
                    int index = this.listBox.IndexFromPoint(e.Location);
                    if (index != ListBox.NoMatches)
                    {
                       listBox.Items[index];
                    }
                }
    
            }
