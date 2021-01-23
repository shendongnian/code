    public class MyTextBox:TextBox
    {
        bool down = false;
        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (!down)
                base.OnKeyDown(e);
            else
                e.SuppressKeyPress = true;
            down = true;
        }
        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
            down = false;
        }
    }
