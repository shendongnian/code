    public class MyDataGrid : DataGridView
    {
        public override void ColumnHeaderMouseClick(...)
        {
           //insert here your code and comment last line, so base class will not call it's own implementation
    
           base.ColumnHeaderMouseClick(...); //after execution of this, the event is reaised
        }
    }
