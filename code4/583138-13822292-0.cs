    public class ListSection
    {
       private String _caption;
       private String _columnHeader1, _columnHeader2, _columnHeader3;
       private BaseAdapter _adapter;
       public ListSection(String caption, String columnHeader1, String columnHeader2, String columnHeader3, BaseAdapter adapter)
       {
          _caption = caption;
          _columnHeader1 = columnHeader1;
          _columnHeader2 = columnHeader2;
          _columnHeader3 = columnHeader3;
          _adapter = adapter;
       }
       public String Caption { get { return _caption; } set { _caption = value; } }
       public String ColumnHeader1 { get { return _columnHeader1; } set { _columnHeader1 = value; } }
       public String ColumnHeader2 { get { return _columnHeader2; } set { _columnHeader2 = value; } }
       public String ColumnHeader3 { get { return _columnHeader3; } set { _columnHeader3 = value; } }
       public BaseAdapter Adapter { get { return _adapter; } set { _adapter = value; } }
    }
