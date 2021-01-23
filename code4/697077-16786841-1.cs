     protected override void OnKeyPress(KeyPressEventArgs e)
        {
            e.Handled = !Char.IsLetter(e.KeyChar) && (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Space);
            base.OnKeyPress(e);
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.V))
                return true;
            else
                return base.ProcessCmdKey(ref msg, keyData);
        }
        private void txtType1_KeyPress(object sender, KeyPressEventArgs e)
        {
            {
                if (char.IsLetter(e.KeyChar) ||
                    char.IsSymbol(e.KeyChar) ||
                    char.IsWhiteSpace(e.KeyChar) ||
                    char.IsPunctuation(e.KeyChar))
                    e.Handled = true;
            }
                  
            {
                string value = txtType1.Text;
                if (txtType1.Text !="")
                    
                {
                    if (Int16.Parse(value) < 1 )
                    {
                        txtType1.Text = ""; 
                    }
                    else if (Int16.Parse(value) > 100)
                    {
                        txtType1.Text = "";
                    }
                   
                    }
                }
            }
        private void txtType1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                MessageBox.Show("Copy/Past not allowed");
            }
