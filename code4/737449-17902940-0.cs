    private double GetValue(string input)
    {
      double val;
    
      if(!double.TryParse(input,out val))
      {
        return val;
      }
    
      return 0;
    }
    
    var sum = this.Controls.OfType<TextBox>().Sum(t => GetValue(t.Text));
