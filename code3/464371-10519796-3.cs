    public void dropdown(string defaultPath)
                {
                    string[] dispDirectories = Directory.GetDirectories(defaultPath, "Data*");
                    comboBox1.Items.Clear();
                    comboBox1.Items.AddRange(dispDirectories);
                }
