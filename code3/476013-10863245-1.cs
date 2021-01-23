    private void button1_Click(object sender, EventArgs e)
        {
            string[] filePaths = Directory.GetFiles(textBox1.Text);
            Process process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.UseShellExecute = false;
            process.EnableRaisingEvents = false;
            
            for (int i = 0; i < filePaths.Length; i++)
            {
                if (i == 0) { label1.Text = "Working On first task"; }
                process.StartInfo.Arguments = "/C " + "@" + "\"" + filePaths[i] + "\"" + " /quiet /norestart";
                process.Start();
                process.WaitForExit();
                label1.Text = (100 * i / filePaths.Length).ToString() + " % is done"; 
                
            }
            label1.Text = "Done";
            
        }
