            EventWaitHandle ProgramOpen = new EventWaitHandle(false, EventResetMode.ManualReset, "ProgramOpen198472");
            EventWaitHandle FocusProgram = new EventWaitHandle(false, EventResetMode.ManualReset, "FocusMyProgram198472");
            private delegate void focusConfirmed(); Thread FocusCheck; 
            private void focus() { FocusProgram.WaitOne(); this.Invoke(new focusConfirmed(()=>{this.Show(); this.BringToFront();}));}
            private void Form1_Load(object sender, EventArgs e)
            {
                if (ProgramOpen.WaitOne(0))
                {
                    FocusProgram.Set();
                    this.Close();
                }
                ProgramOpen.Set();
            }
    
            private void HideButton_Click(object sender, EventArgs e)
            {
                this.Hide();
                FocusProgram.Reset();
                FocusCheck = new Thread(focus);
                FocusCheck.Start();
            }
    
            private void showToolStripMenuItem_Click(object sender, EventArgs e)
            {
                FocusProgram.Set();
            }
