    class YourAppenderClass {
        private FrmMain _form;
        public YourAppenderClass(FrmMain form) {
            _form = form;
        }
        public void AddMessage(string msg) {
            _form.TxtMessageList.Text += msg + Environment.NewLine;
        }
    }
