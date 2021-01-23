    public class SelectableDataObject
    {
    
       public SelectableDataObject(MyDataObject obj)
       {
          this.DataObject = obj;
       }
    
       public MyDataObject DataObject { get; private set; }
       public bool Selected {get;set;}
    
    }
