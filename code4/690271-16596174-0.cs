    public object lb_item = null;
    private void listBox1_DragLeave(object sender, EventArgs e)
    {
        ListBox lb = sender as ListBox;
        lb_item = lb.SelectedItem;
        lb.Items.Remove(lb.SelectedItem);
    }
    private void listBox1_DragEnter(object sender, DragEventArgs e)
    {       
        if (lb_item != null)
        {
            listBox1.Items.Add(lb_item);
            lb_item = null;
        }
    }
    private void listBox1_MouseDown(object sender, MouseEventArgs e)
    {
        lb_item = null;
        if (listBox1.Items.Count == 0)
        {
            return;
        }                
        int index = listBox1.IndexFromPoint(e.X, e.Y);
        string s = listBox1.Items[index].ToString();
        DragDropEffects dde1 = DoDragDrop(s, DragDropEffects.All);      
    }
    private void Form1_DragDrop(object sender, DragEventArgs e)
    {            
        lb_item = null;
    }
