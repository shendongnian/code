    public class Sheet
    {
        ....
        public void AddRow(object[] values)
        {
            var row = new Row();
            foreach(var val in values) 
            {
               var cell = new Cell(val);
               cell.CellChanged += MyCellChangedHandler;
            }
        }
    }
    public class Cell
    {
        ....
 
        public Cell(object value)
        {
            var eventProvider = value as IMyEventProvider; //can be anything you want, INotifyPropertyChanges?
            if (eventProvider != null)
                eventProvider.SomeEvent += SomeEventHandler;
        }
        public SomeEventHandler(...)
        {
            if (CellChanged != null) CellChanged(...);
        }
    }
