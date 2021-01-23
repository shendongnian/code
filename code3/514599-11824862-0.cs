    public class MyTextBox : TextBox
    {
        protected override void OnKeyUp(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D0)
                e.SuppressKeyPress = true;
        }
    }
