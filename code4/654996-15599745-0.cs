    protected void Button1_Click(object sender, EventArgs e)
    {
        for (int i = chkItems.Items.Count -1 ; i >= 0; i--)
        {
            if (chkItems.Items[i].Selected == true)
            {
               chkItems.Items.RemoveAt(i);
            }
        }
    
    }
