    public class SimpleMessageBox:System.Windows.Forms.Form
    {
        public SimpleMessageBox()
        {
        }
        public SimpleMessageBox(string text, string buttonText1, string buttonText2)
        {
           lblMessage.Text = text;
           button1.Text = buttonText1;
           button2.Text = buttonText2;
        }
