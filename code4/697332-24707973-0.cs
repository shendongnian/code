        private void chartTracking_MouseEnter(object sender, EventArgs e)
        {
            this.chartTracking.Focus();
        }
        private void chartTracking_MouseLeave(object sender, EventArgs e)
        {
            this.chartTracking.Parent.Focus();
        }
