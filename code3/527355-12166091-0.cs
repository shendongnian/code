    protected void drpPOMedList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        var indexTextMapping = new Dictionary<int, string>
        {
            { 1, "PO Med not Selected" },
            { 2, "0 / 0" },
            { 3, "8 / 20" }
        };
        lblPOLimit1.Text = indexTextMapping[drpPOMedList1.SelectedIndex];
    }
