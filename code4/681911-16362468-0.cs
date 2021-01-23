    private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
           XDocument ListBoxOptions = XDocument.Load(Filename);
            foreach (XElement element in ListBoxOptions.Root.Elements())
            {  
            if (element.Name.LocalName.Contains("gjester"))
                {
                foreach (XElement subelement in element.Elements())
                   {
                   if (subelement.Name.LocalName.Contains("gjest"))
                       {
                       // What do you want to add? The Attribute? Element value
                        listbox1.Items.Add(element.Value.ToString());
                       } 
                   }   
                }
            }
    }
