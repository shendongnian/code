    private void listBox1_MouseDown(object sender, MouseEventArgs e)
    {
        var item = (Item)listBox1.Items[listBox1.IndexFromPoint(e.X, e.Y)];
        if (e.Button == System.Windows.Forms.MouseButtons.Right)
        {
            item.Enabled = false;
        }
        else
        {
            item.Enabled = true;
        }
    }
