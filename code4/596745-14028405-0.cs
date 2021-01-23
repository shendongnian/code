    public delegate void WriteLogEntryDelegate(string log_entry);
        void WriteLogEntryCB(string log_entry)
        {
            if (richTextBox1.InvokeRequired == true)
            {
                var d = new WriteLogEntryDelegate(WriteLogEntryCB);
                this.Invoke(d, log_entry);
            }
            else
            {
                richTextBox1.AppendText(log_entry + "\r\n");
                this.richTextBox1.SelectionStart = this.richTextBox1.Text.Length;
                this.richTextBox1.ScrollToCaret();
            }
        }
