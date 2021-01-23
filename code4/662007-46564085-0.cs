    public class TextBox : System.Windows.Forms.TextBox
    {
        public TextBox()
        {
            BorderStyle = BorderStyle.None;
            Text = "__________"; //Sometime this doesn't work while creating the control in design mode ; don't know why
        }
        //protected override void OnFontChanged(EventArgs e)
        //{
        //    base.OnFontChanged(e);
        //    RefreshHeight();
        //}
        bool loaded = false;
        protected override void OnCreateControl()
        {
            if(!loaded)
                RefreshHeight();
            base.OnCreateControl();
        }
        private void RefreshHeight()
        {
            loaded = true;
            Multiline = true;
            Size s = TextRenderer.MeasureText(Text, Font, Size.Empty, TextFormatFlags.TextBoxControl);
            MinimumSize = new Size(0, s.Height + 1);
            Multiline = false;
        }
    }
