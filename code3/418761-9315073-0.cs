        private void label1_Click(object sender, EventArgs e)
        {
            var lbl = (Label)sender;
            var toggle = lbl.ForeColor == SystemColors.ControlText;
            lbl.ForeColor = toggle ? Color.Red : SystemColors.ControlText;
        }
