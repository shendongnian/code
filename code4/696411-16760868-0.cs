    public bool ValidateIntTextBoxes(params TextBox[] textBox)
    {
        return textBox.All(t => { 
                                  int value = 0; 
                                  return int.TryParse(textBox.ToString(), out value); 
                                });
    }
