        Textbox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Textbox1_KeyPress);
        Textbox1.MaxLength = 13;
        Textbox1.Validating += new CancelEventHandler(Textbox1_Validating);
        private void Textbox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
        void Textbox1_Validating(object sender, CancelEventArgs e)
        {
            if(Textbox1.Text.Trim().Length != 13)
            {
                e.Cancel = true;
            }
            else if(Convert.ToInt64(Textbox1.Text.Trim()[12] ) != 0) {
                e.Cancel = true;
            }
            else e.Cancel = false;
        }
