    public partial class TextItemView : UserControl
    {
        [ViewCommand]
        public void FocusText()
        {
            MyTextBox.Focus();
        }
    }
