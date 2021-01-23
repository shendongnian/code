    private void btnCalc_Click(object sender, EventArgs e)
    {
        //string A = txtInput.Text;
        string[] arrText = txtInput.Text.Split(',');
        txtOutput.Text = string.Join(",",arrText.Select( s => int.Parse(s)).OrderByDescending( i => i))
    }
