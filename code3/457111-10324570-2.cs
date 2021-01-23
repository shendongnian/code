    public class TextBoxWithoutFocus : TextBox
    {
        public TextBoxWithoutFocus()
        {
            SetStyle(ControlStyles.Selectable, false);
        }
    }
