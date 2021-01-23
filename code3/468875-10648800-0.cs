        private void Form1_Load(object sender, EventArgs e)
        {
            Process p = Process.GetProcessesByName("Notepad")[0];
            p.EnableRaisingEvents = true;
            p.Exited += new EventHandler(p_Exited);
        }
        void p_Exited(object sender, EventArgs e)
        {
            MessageBox.Show("Exit");
        }
