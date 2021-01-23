     private void btnMultiply_Click(object sender, EventArgs e)
            {
                total1 = total1 + double.Parse(txtDisplay.Text);
                txtDisplay.Clear();
    
                plusButtonClicked = false;
                minusButtonClicked = false;
                divideButtonClicked = false;
                multiplyButtonClicked = true;
            }
