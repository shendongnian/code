        private void Say(string s)
        {
            try
            {
                txtSay.AppendText(s + "\r\n");
            }
            catch  // empty catch-block: the real fundamental problem
            {
            }
        }
