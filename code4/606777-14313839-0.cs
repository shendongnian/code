    private void btn_Decimal_Click(object sender, EventArgs e)
    {
        decimal num;
        if (!Decimal.TryParse(txt_Result.Text, out num))
        {
            MessageBox.Show(txt_Result.Text + " is not a valid number.");
            return;
        }
    
        if (txt_Result.Text == "" || LastcharIssymbol==true)
            txt_Result.Text = txt_Result.Text + 0 + ".";
        else
            txt_Result.Text = txt_Result.Text + ".";
    }
