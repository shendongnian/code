        private void txtNumCL_TextChanged(object sender, EventArgs e)
        {
            bool ctrl = Int32.TryParse(txtNumCL.Text, out int outParse);
            if (!ctrl && txtNumCL.Text.Length > 0)
            {
                txtNumCL.Text = txtNumCL.Text.Substring(0, txtNumCL.Text.Length - 1);
                txtNumCL.SelectionStart = txtNumCL.Text.Length;
            }
        }
