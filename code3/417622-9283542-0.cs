    addButton.Tag = Operation.Add;
    subtractButton.Tag = Operation.Subtract;
    addButton.Multiply = Operation.Multiply;
    addButton.Divide = Operation.Divide;
    public Operation Operation         
    {             
      get             
      {
        RadioButton checkedButton = gbxOperation.Controls.OfType<RadioButton>().
                                                 Where(button => button.Checked).First();
        return (Operation)(checkedButton.Tag);
      }
    }   
