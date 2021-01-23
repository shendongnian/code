    XmlDocument doc = new XmlDocument();
    doc.Load("att.xml");
    foreach(XmlNode item in doc.SelectNodes("//item"))
        comboBox1.Items.Add(item.Attributes["name"].Value);
    void button3_Click(object sender, NotifyArgs e)
    {
        XmlNode item = doc.SelectSingleNode("//item[@name='" + comboBox1.Text + "']");
        if (item == null) return;
        item.Attributes["name"].Value = textBox1.Text;
        ...
        doc.Save("att.xml");
    }
