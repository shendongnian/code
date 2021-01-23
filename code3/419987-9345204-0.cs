        private delegate void NameCallBack(string varText);
        public void SetNameTextBox(string log) {
            if (InvokeRequired) {
                textBox.BeginInvoke(new NameCallBack(SetNameTextBox), new object[] {log});
            } else {
                textBox.Text = log;
            }
        }
