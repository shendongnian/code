      string lastused = "";
          
            if (MyConfigurationSettings.ConfigSettings.ContainsKey("openFileDialog2_last_used"))
            {
              MyConfigurationSettings.ConfigSettings.TryGetValue("openFileDialog2_last_used", out lastused);
            }
            if (lastused != "")
            {
                openFileDialog2.InitialDirectory = lastused;
            }
            else
            {
                openFileDialog2.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            }
            string filestring = "";
            if (template_filename == "")
            {
                try
                {
                    if (openFileDialog2.ShowDialog() == DialogResult.OK)
                    {
                        filestring = openFileDialog2.FileName;
                        String chosenPath = Path.GetDirectoryName(openFileDialog2.FileName);
                        Dictionary<String, String> settings_to_save = new Dictionary<String, String>();
                        settings_to_save.Add("openFileDialog2_last_used", chosenPath);
                        settings_to_save.Add("openFileDialog2_last_used_template_file", filestring);
                        UpdateConfig(settings_to_save);
    }
             else return;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("There was an error.", "Invalid File", MessageBoxButtons.OK);
                    return;
                }
    private void YOURFORMNAME_Load(object sender, EventArgs e)
        {
    // Load configuration file          
    LoadConfig();
        }
     private void YOURFORMNAME_FormClosing(object sender, FormClosingEventArgs e)
        {
    // Save configuration file
            SaveConfig();
        }
