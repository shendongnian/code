    private void btnDelete_Click(object sender, EventArgs e)
    {
        var xDoc = XDocument.Load(strFilename);
        foreach (var elem in xDoc.Document.Descendants("product"))
        {
            foreach (var attr in elem.Attributes("name"))
            {
                if (attr.Value.Equals("Tide"))
                    elem.RemoveAll();
            }
        }
        xDoc.Save(destinationFilename);
        MessageBox.Show("Deleted Successfully");
    }
