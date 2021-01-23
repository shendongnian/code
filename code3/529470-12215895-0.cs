    protected void btn_OnClick(object sender, EventArgs e)
    {
        for (int i = 0; i < countries.Items.Count; i++)
        {
            if (countries.Items[i].Selected)
            {
                // do something
                // countries.Items[i].Value;
            }
        }
    }
