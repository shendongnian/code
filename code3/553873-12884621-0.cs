    public string isHighorLow(int number)
    {    
        if (number >= 50)
            return "High";
        return "Low";
    }
    numbers info = new numbers();
    private void Btn_Click(object sender, EventArgs e)
    { 
        info.numProperty = Convert.ToInt32(numberBOX.Text);
        MessageBox.Show(info.isHighorLow());
    }
