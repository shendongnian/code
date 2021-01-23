        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Middle)
            {
                this.Deactivate += new EventHandler(Form1_Deactivate);
                System.Diagnostics.Process.Start(this.linkLabel1.Text);
            }
        }
        void Form1_Deactivate(object sender, EventArgs e)
        {
            this.Deactivate -= new EventHandler(Form1_Deactivate);
            SetForegroundWindow(this.Handle);
        }
