    if (!string.IsNullOrEmpty(txtSolution.Text) && string.IsNullOrEmpty(txtRemarks.Text))
            {
                txtSolution.Focus();
            }
            else if (!string.IsNullOrEmpty(txtRemarks.Text))
            {
                txtRemarks.Focus();
            }
