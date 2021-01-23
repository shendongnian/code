        public static readonly Main MainLogWindow = new Main();
        private delegate void NameCallBack(string varText);
        public void UpdateTextBox(string input) {
            if (InvokeRequired) {
                textBox.BeginInvoke(new NameCallBack(UpdateTextBox), new object[] {input});
            } else {
                textBox.AppendText = input;
            }
        }
