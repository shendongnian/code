    private int _number; 
    private string GetNumber(int number)
    {
        _number = number;
        return number .ToString();
    }
    public int Number
    {
        get { return _number; }
        set { _number = value; }
    }
    public string IsHigh()
    {   
        get { if (number >= 50) return true; }
    }
    numbers info = new numbers();
    private void Btn_Click(object sender, EventArgs e)
    { 
        info.Number = Convert.ToInt32(numberBOX.Text);
        MessageBox.Show(info.IsHigh ? "High" : "Low");
    }
