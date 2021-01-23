        ...
        protected void ping_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.destination.Text))
            {
                string strCmdText = string.Concat("ping ", this.destination.Text.Trim());
                System.Diagnostics.Process.Start("CMD.exe", strCmdText);
                //and so on...
            }
        }
        ...
