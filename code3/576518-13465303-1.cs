    namespace WindowsFormsApplication1
    {
        public delegate void CustomEventHandler(object sender, CustomEventArgs a);
 
        public partial class Form2 : Form
        {
            public event CustomEventHandler RaiseCustomEvent;
            public Form2()
            {
                InitializeComponent();
            }
            private void button1_Click(object sender, EventArgs e)
            {
                RaiseCustomEvent(this, new CustomEventArgs(textBox1.Text));
            }
        }
        public class CustomEventArgs : EventArgs
        {
            public CustomEventArgs(string s)
            {
                msg = s;
            }
            private string msg;
            public string Message
            {
                get { return msg; }
            }
        }
    }
