        public string DataFormat, KeyboardFormat;
        private void CMDSubmit_Click(object sender, EventArgs e)
        {
            if (RB_D_1.Checked)
                DataFormat = RB_D_1.Text;
            else if (RB_D_2.Checked)
                DataFormat = RB_D_2.Text;
            else if (RB_D_3.Checked)
                DataFormat = RB_D_3.Text;
            else if (RB_D_4.Checked)
                DataFormat = RB_D_4.Text;
            else
                DataFormat = "MM/DD/YYYY"; // default format
            //--------------------------------
            if (RB_L_1.Checked)
                KeyboardFormat = RB_L_1.Text;
            else if (RB_L_2.Checked)
                KeyboardFormat = RB_L_2.Text;
            else if (RB_L_3.Checked)
                KeyboardFormat = RB_L_3.Text;
            else if (RB_L_4.Checked)
                KeyboardFormat = RB_L_4.Text;
            else
                KeyboardFormat = "QWERTY"; // default format
            this.Close();
        }
