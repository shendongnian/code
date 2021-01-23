    private void generateXml(XmlWriter writer, Control receivedControl)
    {
        foreach (Control subCtrl in receivedControl.Controls)
        {
                writer.WriteStartElement(subCtrl.Name);
                generateXml(writer, subCtrl);
                writer.WriteEndElement();
        }
    }
    private void button2_Click(object sender, EventArgs e)
    {
        using (XmlWriter writer = XmlWriter.Create("C:\\ui.xml"))
        {
            writer.WriteStartDocument();
            writer.WriteStartElement(this.Name); // This is the document element
            foreach (Control c in this.Controls)
            {
                generateXml(writer, c);
            }
            writer.WriteEndDocument(); // Close any open tags
        }
    }
