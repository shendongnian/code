    public listclass()
    {
      this.ListChanged += new ListChangedEventHandler(listclass_ListChanged);
    }    
    void listclass_ListChanged(object sender, ListChangedEventArgs e)
    {
      if (e.ListChangedType == ListChangedType.ItemAdded)
      {
        item item = this[e.NewIndex];
        item.PropertyChanged += new PropertyChangedEventHandler(Item_PropertyChanged);
      }
    }
    
    void Item_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
       if (e.PropertyName == "propertyname")
       {
            
       }     
    }
