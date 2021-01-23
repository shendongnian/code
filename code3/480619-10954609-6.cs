    private void Load_Click(object sender, RoutedEventArgs e)
    {
        var xmlDocument = new XmlDocument();
        xmlDocument.Load("People.xml");
        people.Document = xmlDocument;
    }
    private void Save_Click(object sender, RoutedEventArgs e)
    {
        XmlDocument xml = people.Document;
        if (xml != null)
        {
            Microsoft.Win32.SaveFileDialog sfd = new Microsoft.Win32.SaveFileDialog();
            if ((bool)sfd.ShowDialog(this))
            {
                xml.Save(sfd.FileName);
            }
        }
    }
