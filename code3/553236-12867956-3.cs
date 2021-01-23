    private void btnEnter_Click(object sender, EventArgs e)
    {
        lblThanks.Text = "Thank you" + (" ") + txtFirstName.Text + (" ") + txtLastName.Text + "!";
        txtCakesOrdered.Text = nudCakes.Value.ToString();
        Cost obj=new Cost();
        obj.BasePrice = 20;
        obj.Tax=1.13;
        txtTotalCost.Text = (obj.BasePrice * Convert.ToDouble(nudCakes.Value) * obj.Tax).ToString("C");
        grpOutput.Visible = true; 
    }
