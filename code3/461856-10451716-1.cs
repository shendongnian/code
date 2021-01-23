    private void btnMinus_Click(object sender, EventArgs e)
            {
                plusButtonClicked = false;
                minusButtonClicked = true;
                divideButtonClicked = false;
                multiplyButtonClicked = false;
    
                total1 = total1 + double.Parse(txtDisplay.Text);
                txtDisplay.Clear();
            }
