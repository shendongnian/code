    public class XMLDataSource : DataSource
    {
      internal XMLDataSource() { }
    }
    public class SqlDataSource : DataSource
    {
      internal SqlDataSource() { }
    }
    public class CSVDataSource : DataSource
    {
      public int MyProperty { get; set; }
      internal CSVDataSource() { }
      public override string ToString()
      {
          return "CSVDataSource";
      }
    }
