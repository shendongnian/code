        private void Form1_Load(object sender, EventArgs e)
        {
            //check load count...
            int loadCount = ApplicationSettingsDemo.Properties.Settings.Default.LoadCount;
            if (loadCount > 10)
            {
                MessageBox.Show("Trial version!");
            }
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                  ApplicationSettingsDemo.Properties.Settings.Default.LoadCount += 1;
                  ApplicationSettingsDemo.Properties.Settings.Default.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                    "Failed to save settings", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
            }
        }
