    public class MyButton : Button
    {
        protected override void OnMouseRightButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseRightButtonDown(e); // this line probably optional/not required
            base.OnMouseLeftButtonDown(e);
        }
        protected override void OnMouseRightButtonUp(MouseButtonEventArgs e)
        {
            base.OnMouseRightButtonUp(e); // this line probably optional/not required
            base.OnMouseLeftButtonUp(e);
        }
    }
