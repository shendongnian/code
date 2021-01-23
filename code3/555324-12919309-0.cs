    StringBuilder _code = new StringBuilder();
    void button1_Click(object sender, EventArgs e)
    {
        _code.Append('1');
      CheckCode();
    }
    // ... similarly implement other button click events
    void CheckCode()
    {
        if (_code.ToString().Contains("13221"))
        {
            MessageBox.Show("ACCESS GRANTED");
        }
    }
