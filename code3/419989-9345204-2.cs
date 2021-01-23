        public static readonly Main MainLogWindow = new Main();
        private delegate void NameCallBack(string varText);
        public void UpdateTextBox(string input) {
            if (InvokeRequired) {
                textBox.BeginInvoke(new NameCallBack(UpdateTextBox), new object[] {input});
            } else {
                textBox.Text = input;
                // textBox.Text = textBox.Text + Environment.NewLine + input // This might work as append in next line but haven't tested so not sure
            }
        }
