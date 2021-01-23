    public void dropdown(string defaultPath, string filter)
            {
                string[] dispDirectories = Directory.GetDirectories(defaultPath, filter);
                comboBox1.Items.Clear();
                comboBox1.Items.AddRange(dispDirectories);
            }
