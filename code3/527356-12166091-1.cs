    protected void drpPOMedList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        var indexTextMapping = new Dictionary<int, string>
        {
            { 0, "PO Med not Selected" },
            { 1, "0 / 0" },
            { 2, "8 / 20" }
        };
        lblPOLimit1.Text = indexTextMapping[drpPOMedList1.SelectedIndex];
    }
