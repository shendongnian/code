    private void buttonTab4Mod1Calculate_Click(object sender, EventArgs e)
    {
        var document = XDocument.Load(workingDir + @"\Level4.xml");
        string selectedItem = (string) comboBoxTab4Mod8.SelectedItem;
        var assessmentOneWeight = from d in document.Descendants("moduleTitle")
                                  where (string) d == selectedItem
                                  select (int) d.Parent.Element("assessmentOneWeight");
        foreach (int item in assessmentOneWeight)
        {
             MessageBox.Show(item.ToString());
        }        
    }
