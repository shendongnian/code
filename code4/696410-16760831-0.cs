    public bool ValidateIntTextBoxes(params TextBox[] textBox)
    {
       bool valid = true;
       int value;
       foreach(var t in textBox){
         if((int.TryParse(t.Text.Trim(), out value) == false) {
            return false;
        }
      }
      return valid;
    }
