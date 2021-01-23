    bool rightClicked = false;
    private void listView1_MouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button == System.Windows.Forms.MouseButtons.Right)
        {
            rightClicked = true;
        }
        else
        {
            rightClicked = false;
        }
    }
    private void listView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rightClicked)
        {
            listView1.SelectedItems.Clear();
        }
        
    }
    private void listView1_MouseUp(object sender, MouseEventArgs e)
    {
        rightClicked = false;
    }
