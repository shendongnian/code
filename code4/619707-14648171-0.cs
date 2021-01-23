        Textbox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Textbox1_KeyPress);
        Textbox1.MaxLength = 13;
        private void Textbox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
