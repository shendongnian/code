    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if ((keyData == (Keys.Control | Keys.V)))
            {
                Debug.WriteLine("Pasted!");
                this.SuspendLayout();
                ProcessAllLines();
                this.ResumeLayout();
                return base.ProcessCmdKey(ref msg, keyData);
            }
            else
            {
                return base.ProcessCmdKey(ref msg, keyData);
            }
        }
