    public class MyRichTextBox : RichTextBox
    {
        ...
        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            // Your background painting logic goes here
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            // Your foreground painting logic goes here
        }
    }
