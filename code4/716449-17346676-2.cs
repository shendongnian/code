    private void Filter(FilterState filter)
        {
            ApplesA.Visible = ApplesB.Visible = ApplesC.Visible = filter.HasFlag(FilterState.Apples);
            OrangesA.Visible = OrangesB.Visible = OrangesC.Visible = OrangesD.Visible = filter.HasFlag(FilterState.Oranges);
            StrawberriesA.Visible = StrawberriesB.Visible = StrawberriesC.Visible = StrawberriesD.Visible = filter.HasFlag(FilterState.Automation);
            CherriesA.Visible = CherriesB.Visible = CherriesC.Visible = filter.HasFlag(FilterState.Cherries);
        }
        private void filterPolicyBtn_Click(object sender, EventArgs e)
        {
            var filter = FilterState.All;
            if (ApplesCheck.Checked) filter = FilterState.Apples;
            if (OrangesCheck.Checked) filter =  FilterState.Oranges;
            if (StrawberriesCheck.Checked) filter = FilterState.Automation;
            if (CherriesCheck.Checked) filter = FilterState.Cherries;
            
            Filter(filter);
        }
        
        private void ShowAll_Click(object sender, EventArgs e)
        {
            Filter(FilterState.All);
        }
