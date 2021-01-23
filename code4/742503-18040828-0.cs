    Process p1 = Process.Start(Path.GetFullPath(zippedFileDirectory));
    Process p2 = Process.Start(Path.GetFullPath(temp));
    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Are you Sure you want to Exit. Click Yes to Confirm and No to continue", "WinForm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
               p1.Kill();
               p2.Kill();
            }
        }
    
