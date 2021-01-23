    public class YourForm
    {
        private bool _formClosing = false; // Keep track of form closing
    
        public YourForm()
        {    
            this.FormClosing += FormClosingHandler;
        }
    
        protected void FormClosingHandler(object sender, FormClosingEventArgs e)
        {
            _formClosing = true;
        }
    
        private void appendText(string s)
        {
          if (_formClosing) // If form is closing, we dont want to append anymore
            return;
    
          if (InvokeRequired)
          {
              this.Invoke(new Action<string>(appendText), new object[] { s });
              return;
          }
    
          SocketStream.AppendText(s + "\r\n");
        }
        // Socket handling; also check for _formClosing
    }
