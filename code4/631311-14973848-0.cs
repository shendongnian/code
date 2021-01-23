    public abstract class Control
    {
        // ...
    }
    public class TextBox : Control
    {
        public virtual string Text { get; set; }
    }
    public class MaskedTextBox : TextBox
    {
        public virtual string Mask { get; set; }
    }
