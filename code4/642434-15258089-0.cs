    /// <summary>
    /// Check to make sure the input is valid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void CheckNumberValidationHandler(object sender, TextCompositionEventArgs e) {
        if(IsTextAllowed(e.Text)) {
        Int32 newVal;
        newVal = Int32.Parse(LimitInt.ToString() + e.Text);
        if(newVal < 0) {
            LimitInt = 0;
            e.Handled = true;
        }
        else if(newVal > 300) {
            LimitInt = 300;
            e.Handled = true;
        }
        else {
            e.Handled = false;
        }
        }
        else {
        e.Handled = true;
        }
    }
    /// <summary>
    /// Check if Text is allowed
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    private static bool IsTextAllowed(string text) {
        Regex regex = new Regex("[^0-9]+");
        return !regex.IsMatch(text);
    }
