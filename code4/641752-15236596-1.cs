    public abstract class CustomControlBase : Control
    {
        public virtual bool HasText
        {
            get { return false; }
        }
    }
    
    public class MyCustomControl : CustomControlBase
    {
        public override bool HasText
        {
            get { return true; }
        }
        
        public override string Text
        {
            get { /* Do something. */ }
            set { /* Do something. */ }
        }
    }
    
    public static bool HasWorkingTextProperty(Control control)
    {
        return (control is CustomControlBase && ((CustomControlBase)control).HasText)
            || control is Label
            || control is TextBox
            || control is ComboBox;
    }
