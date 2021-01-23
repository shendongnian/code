    private void Load()
    {        
            XElement Persons = XElement.Load(@"d:\persons.xml");
    
            System.ComponentModel.ICollectionView c = CollectionViewSource.GetDefaultView(Persons.Elements);
    		c.Filter = new Predicate<XElement>(CollectionViewSource_Filter);
    
    		dataGrid1.ItemsSource = c;
    }
    
    private object CollectionViewSource_Filter(XElement i)
    {
    		return i.Element("name").Value.ToString.Contains(textBox1.Text);
    }
