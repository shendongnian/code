    private void Load()
    {        
            XElement Persons = XElement.Load(@"d:\persons.xml");
    
            System.ComponentModel.ICollectionView c = System.Windows.Data.CollectionViewSource.GetDefaultView(Persons.Elements());
    		c.Filter = new Predicate<object>(CollectionViewSource_Filter);
    
    		dataGrid1.ItemsSource = c;
    }
    
    private Boolean CollectionViewSource_Filter(object i)
    {
    		return (i as XElement).Element("name").Value.ToString.Contains(textBox1.Text);
    }
