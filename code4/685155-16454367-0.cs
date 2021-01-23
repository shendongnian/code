    class MyDialog : Form
    {
        private BlackBox b;
        public MyDialog(BlackBox b) : this()
        {
            this.b = b;
            b.messageReceived += myNewFunction;
        }
        private void myNewFunction(string s)
        {
            // this function never ends up being called
        }
    }
