    public bool ValidateIntTextBoxes(params TextBox[] textBox)
    {
        return textBox.All(t => { 
                                  int value = 0; 
                                  return int.TryParse(t.Text, out value); 
                                });
    }
