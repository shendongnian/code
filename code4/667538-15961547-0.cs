    private void button1_Click(object sender, EventArgs e)
    {
        var something = new Process {
            StartInfo = new ProcessStartInfo {
                FileName = "something.exe",
                CreateNoWindow=true,
                UseShellExecute=false
            }
        };
        if (File.Exists("something.exe")) {
            this.Enabled = false;
            something.Start();
            something.WaitForExit();
            this.Enabled = true;
        } else {
            MessageBox.Show("Message.", "Title", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
