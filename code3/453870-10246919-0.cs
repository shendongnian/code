    public class Control1 : Control, ICustomControl
    {
        public string SomeProperty
        {
            get { return someControl.Text; }
            set { someControl.Text = value; }
        }
        // ...
    }
