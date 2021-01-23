    private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
    {
        using (SaveFileDialog dialog = new SaveFileDialog())
        {
            dialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            dialog.FilterIndex = 2;
            dialog.RestoreDirectory = true;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                // Can use dialog.FileName
                //using (Stream stream = dialog.OpenFile())
                //{
                // Save data
                inmo.GenereateSettingsFile(_nodeList, dialog.FileName);
                //}
            }
        }
    }
    public void GenereateSettingsFile(List<Node> nodeList, string filePath)
    {
        //string filePath = "Desktop\\Save.xml";
        _rootNode.RemoveChild(_userNode);
        _userNode = _xmlDoc.CreateElement("Display_Settings");
        _rootNode.AppendChild(_userNode);
        foreach (Node n in nodeList)
        {
            foreach (XmlElement e in n.GenerateXML(_xmlDoc))
            {
                _userNode.AppendChild(e);
            }
        }
        _xmlDoc.Save(filePath);
    }
