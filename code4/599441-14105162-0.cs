    Double lastNumber = 0;
    Double total = 0;
    bool minusButtonClicked = false;
    bool plusButtonClicked = false;
    bool divideButtonClicked = false;
    bool multiplyButtonClicked = false;
    private void btnPlus_Click(object sender, EventArgs e)
    {
        lastNumber = Double.Parse(txtDisplay.Text);
        txtDisplay.Clear();
        plusButtonClicked = true;
        minusButtonClicked = false;
        divideButtonClicked = false;
        multiplyButtonClicked = false;
    }
    private void btnMinus_Click(object sender, EventArgs e)
    {
        lastNumber = Double.Parse(txtDisplay.Text);
        txtDisplay.Clear();
        plusButtonClicked = false;
        minusButtonClicked = true;
        divideButtonClicked = false;
        multiplyButtonClicked = false;
    }
    private void btnDivide_Click(object sender, EventArgs e)
    {
        lastNumber = Double.Parse(txtDisplay.Text);
        txtDisplay.Clear();
        plusButtonClicked = false;
        minusButtonClicked = false;
        divideButtonClicked = true;
        multiplyButtonClicked = false;
    }
    private void btnMultiply_Click(object sender, EventArgs e)
    {
        lastNumber = Double.Parse(txtDisplay.Text);
        txtDisplay.Clear();
        plusButtonClicked = false;
        minusButtonClicked = false;
        divideButtonClicked = false;
        multiplyButtonClicked = true;
    }
    private void btnEquals_Click(object sender, EventArgs e)
    {
        if (plusButtonClicked == true)
        {
            total = lastNumber + Double.Parse(txtDisplay.Text);
        }
        else if (minusButtonClicked == true)
        {
            total = lastNumber - Double.Parse(txtDisplay.Text);
        }
        else if (divideButtonClicked == true)
        {
            total = lastNumber / Double.Parse(txtDisplay.Text);
        }
        else if (multiplyButtonClicked == true)
        {
            total = lastNumber * Double.Parse(txtDisplay.Text);
        }
        txtDisplay.Text = total.ToString();
        lastNumber = 0;
    }
