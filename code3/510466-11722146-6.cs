    private void button1_Click(object sender, EventArgs e)
        {
            var textConfiguration = XDocument.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Config.xml"));
            if (textConfiguration != null)
            {
                textConfiguration.Descendants("Configuration").Descendants("text").ToList().ForEach(text =>
                {
                    font = text.Attribute("font").Value;
                    color = text.Attribute("color").Value;
                    fontsize = text.Attribute("font-size").Value;
                    textToAppend = text.Value;
                });
            }
            richTextBox1.SelectionColor = Color.FromName(color);   
            richTextBox1.SelectionFont = new Font(font, int.Parse(fontsize), FontStyle.Regular);
            richTextBox1.AppendText(textToAppend);
        }
