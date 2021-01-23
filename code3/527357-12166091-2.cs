    class SomeClass
    {
        static readonly Dictionary<int, string> INDEX_TEXT_TABLE = new Dictionary<int, string>
        {
            { 0, "PO Med not Selected" },
            { 1, "0 / 0" },
            { 2, "8 / 20" }
        };
        protected void drpPOMedList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblPOLimit1.Text = INDEX_TEXT_TABLE[drpPOMedList1.SelectedIndex];
        }
    }
