    public class RegexTextBox:TextBox
    {
       [Category("Behavior")]
       public string RegexPattern {get;set;}
       
       protected override OnKeyPress(KeyPressEventArgs e)
       { 
          if (!Regex.IsMatch(this.Text + e.KeyChar, RegexPattern)) e.Handled = true;
          else base.OnKeyPress(e);
       }
    }
