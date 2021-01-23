    protected void CheckBox_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            CheckBox cb = sender as CheckBox;
            GridViewRow gr = cb.Parent.Parent as GridViewRow;
            string key = GridView1.DataKeys[gr.DataItemIndex].Value.ToString();
        }
        catch (Exception exc)
        {
        }
    }
