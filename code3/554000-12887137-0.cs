    public class MyRichTextBox : RichTextBox {
        
        protected override void New() {
            base.New();
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }
    }
