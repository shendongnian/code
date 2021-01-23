    private void RadioButtonCheckedChanged(object sender, EventArgs e)
    {
        var radioButton = (RadioButton)sender;
        if (radioButton.Checked)
        {
            switch (radioButton.Text)
            {
                case "Add":
                    label3.Text = "+";
                    break;
                case "Subtract":
                    label3.Text = "-";
                    break;
                case "Divison":
                    label3.Text = "/";
                    break;
            }
        }
    }
