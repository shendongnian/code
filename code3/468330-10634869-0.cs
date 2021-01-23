        private void button1_Click(object sender, EventArgs e) {
            try {
                chart1.Series[0].Label = "#VAL{";
                chart1.Refresh();
            }
            catch {
                MessageBox.Show("Exception caught");
            }
        }
