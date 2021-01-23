    if (txtNum1.Text.Length == 0 && txtNum2.Text.Length == 0)
    {
        MessageBox.Show("No Input Detected");
        txtNum1.Focus();
        txtNum2.Focus();
    }
    else
    {
        int num1 = Convert.ToInt32(txtNum1.Text);
        int num2 = Convert.ToInt32(txtNum2.Text);
        lblTotal.Text = (num1 + num2).ToString();
    }
            
