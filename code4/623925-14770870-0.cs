    void listBox1_DrawItem(object sender, DrawItemEventArgs e)
    {
        var item = listBox1.Items[e.Index] as <Your_Item>;
    
        e.DrawBackground();
        if (item.fIsTemplate)
        {
            e.Graphics.DrawString(item.Text + "(Default)", new Font("Microsoft Sans Serif", 8, FontStyle.Regular), Brushes.Black, e.Bounds);
        }
        else
        {
            e.Graphics.DrawString(item.Text, new Font("Microsoft Sans Serif", 8, FontStyle.Regular), Brushes.Black, e.Bounds);
        }
        e.DrawFocusRectangle();
    }
