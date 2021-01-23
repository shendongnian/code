    enter code here  private void button26_Click(object sender, EventArgs e)
        {
            System.Diagnostics.ProcessStartInfo proc = new System.Diagnostics.ProcessStartInfo();
            proc.FileName = @"C:\windows\system32\cmd.exe";
            proc.Arguments = "/c ping -t " + tx1.Text + " ";
            System.Diagnostics.Process.Start(proc);
            tx1.Focus();
        }
        private void button27_Click(object sender, EventArgs e)
        {
            System.Diagnostics.ProcessStartInfo proc = new System.Diagnostics.ProcessStartInfo();
            proc.FileName = @"C:\windows\system32\cmd.exe";
            proc.Arguments = "/c ping  " + tx2.Text + " ";
            System.Diagnostics.Process.Start(proc);
            tx2.Focus();
        }
