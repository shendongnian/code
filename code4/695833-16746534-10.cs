     private void SetText(string text)
            {
                if (this.txtOutput.InvokeRequired)
                {
                 SetTextCallback d = new SetTextCallback(SetText);
                 this.BeginInvoke(d, new object[] { text });
                }
                else
                {
                    txtOutput.AppendText(text + "\r\n");
                }}
