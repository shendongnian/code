    private void btnMinus_Click(object sender, EventArgs e)
    {
        plusButtonClicked = false;
        minusButtonClicked = true;
        divideButtonClicked = false;
        multiplyButtonClicked = false;
        total1 = total1 - double.Parse(txtDisplay.Text);
        txtDisplay.Clear();
    }
    private void btnDivide_Click(object sender, EventArgs e)
    {
        total1 = total1 / double.Parse(txtDisplay.Text);
        txtDisplay.Clear();
        plusButtonClicked = false;
        minusButtonClicked = false;
        divideButtonClicked = true;
        multiplyButtonClicked = false;
    }
