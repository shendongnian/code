    private void button1_Click(object sender, EventArgs e)
    {
        XDocument doc = XDocument.Load("test.xml");
        // Removes all existing elements
        foreach (XElement xElement in from q in doc.Elements("dogs").Elements("dog")
                                      where q.Attribute("name").Value == textBox1.Text
                                      select q)
            xElement.Remove();
        gender(); //determines in which root node this entry will appear as child node; just comboBox with few exceptions
        TreeViewOperations.SaveTree(treeView1, "test2.xml"); //saving treeView1
        Save("test.xml"); //saving file that contains data form textBoxes etc.
        statusBarUpdate();
    }
