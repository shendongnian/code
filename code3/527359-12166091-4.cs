    class SomeClass
    {
        static readonly Dictionary<string, string> VALUE_TEXT_TABLE = new Dictionary<string, string>
        {
            { "None", "PO Med not Selected" },
            { "Zero", "0 / 0" },
            { "EightTwenty", "8 / 20" }
        };
        protected void drpPOMedList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblPOLimit1.Text = VALUE_TEXT_TABLE[drpPOMedList1.SelectedValue];
        }
    }
