    string enteredText = (sender as TextBox).Text;
    int cursorPosition = (sender as TextBox).SelectionStart;
    string[] splitByDecimal = enteredText.Split('.');
    if(splitByDecimal.Length > 1 && splitByDecimal[1].Length > 2){
        (sender as TextBox).Text = enteredText.Remove(enteredText.Length-1);
        (sender as TextBox).SelectionStart = cursorPosition - 1;
    }
    
