    public class Program
    {
        XDocument document;
        
        private void loadXML()
        {            
            if (configFilePathTextBox.Enabled == true)
            {
                document = XDocument.Load(configFilePathTextBox.Text);
            }
            else
            {
                document = XDocument.Load(Application.StartupPath + @"\config.xml");
            }
            IEnumerable<XElement> elList =
                from el in document.Descendants("software_entry")
                select el;
            foreach (XElement el in elList)
                listBox1.Items.Add(el.Attribute("name"));
            MessageBox.Show("Configuration file loaded successfully.");
        }
    }
