    protected void Page_Load(object sender, EventArgs e)
        {
            XmlTextWriter writer = new XmlTextWriter("your.xml", System.Text.Encoding.UTF8);
            writer.WriteStartDocument(true);
            writer.Formatting = Formatting.Indented;
            writer.Indentation = 2;
            writer.WriteStartElement("AllNews");
            writer.WriteStartElement("News");
            //Loopthrough your dataset/datatable/Or datareader here
            //Call the CreateNode Method from here 
            //End of loop
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Close();
           
        }
        private void createNode(string flag, string title, string desc, string date, XmlTextWriter writer)
        {
            writer.WriteStartElement("GNEWS");
            writer.WriteStartElement("flag");
            writer.WriteString(flag);
            writer.WriteEndElement();
            writer.WriteStartElement("title");
            writer.WriteString(title);
            writer.WriteEndElement();
            writer.WriteStartElement("description");
            writer.WriteString(desc);
            writer.WriteStartElement("date");
            writer.WriteString(date);
            writer.WriteEndElement();
            writer.WriteEndElement();
        }
