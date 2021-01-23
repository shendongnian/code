    private void textBox1_PreviewKeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Space)
        {
            e.Handled = true;
        }
    }
    private void textBox1_PreviewTextInput(object sender, TextCompositionEventArgs e)
    {
        //Create a string combining the text to be entered with what is already there.
        //Being careful of new text positioning here, though it isn't truly necessary for validation of number format.
        int cursorPos = textBox1.CaretIndex;
        string nextText;
        if (cursorPos > 0)
        {
            nextText = textBox1.Text.Substring(0, cursorPos) + e.Text + textBox1.Text.Substring(cursorPos);
        }
        else
        {
            nextText = textBox1.Text + e.Text;
        }
        double testVal;
        if (!Double.TryParse(nextText, out testVal))
        {
            e.Handled = true;
        }
    }
