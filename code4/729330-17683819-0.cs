        private bool capLock;
        private bool numLock;
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.CapsLock)
            {
                capLock = !capLock;
            }
            if (e.KeyCode == Keys.NumLock)
            {
                numLock = !numLock;
            }
        }
