    private async Task button1_Click(object sender, EventArgs e)
    {
        string RealmName = listBox1.Items[listBox1.SelectedIndex].ToString();
    
        bool result = await JsonManager.GetAuctionIndex().Fetch(RealmName);
        if (result)
        {
            label1.Text = JsonManager.GetAuctionIndex().LastUpdate + " ago";
            foreach (string Owner in await JsonManager.GetAuctionDump().Fetch(JsonManager.GetAuctionIndex().DumpURL))
            {
                listBox2.Items.Add(Owner);
            }
        }
    }
