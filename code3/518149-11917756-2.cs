    XElement element;
    XDocument doc;
    
    private void Load()
    {
        doc = XDocument.Load(filePath);
    
        string id = textBox6.Text;
        element = doc.Descendants("Customer").FirstOrDefault(p => p.Attribute("id").Value == id);
    
        if (element != null)
        {
            //found
            textBox6.Text = textBox6.Text;
            textBox1.Text = (string)element.Element("FirstName");
            textBox2.Text = (string)element.Element("LastName"); 
            textBox3.Text = (string)element.Element("Mobile");
            textBox4.Text = (string)element.Element("Address");
            textBox5.Text = (string)element.Element("Country");
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        element.Attribute("id").Value = textBoxID.text;
        var firstNameSimilarElement = doc.Descendants("FirstName").FirstOrDefault(fn => fn.Value == textBox1.Text)
        if (firstNameSimilarElement != null && firstNameSimilarElement.Parent != element)
        {
             MessageBox.Show("First Name already exists");
        }
        else
        {
            element.Element("FirstName").Value = textBox1.Text;
        }
        // Same for all fields
        doc.Save(filePath);
    }
