    BusinessObjList BL = new BL();
    BL.CollectionChanged += new NotifyCollectionChangedEventHandler(bl_CollectionChanged);
    
    static void bl_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
       // handle the change in UI.
    }
