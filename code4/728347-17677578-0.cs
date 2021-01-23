    protected void YourListView_Load(object sender, EventArgs e)
    {
        Label theTWALabel;
        int theTWAValue;
        foreach (ListViewItem item in YourListView.Items)
        {
            theTWALabel = (Label)item.FindControl("TWALabel");
            theTWAValue = Convert.ToInt32(theTWALabel.Text);
            if (theTWAValue >= 85)
            {
                if (theTWAValue < 90)
                    theTWALabel.ForeColor = System.Drawing.Color.Yellow;
                else
                    theTWALabel.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
