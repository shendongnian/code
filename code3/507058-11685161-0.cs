    [Serializable]
    public class ResultsCollection : CollectionBase
    {
      // indexer
      public MyDataSet this[int index] { get { return (MyDataSet)List[index]; } }
    }
    [Serializable]
    public class MyDataSet : DataSet, ISerializable
    {
      // member variable that *overrides* the Tables property of the standard DataSet class
      public new TablesCollection Tables;
    }
    [Serializable]
    public class TablesCollection : CollectionBase
    {
      // indexer
      public MyDataTable this[int index] { get { return (MyDataTable)List[index]; } }
    }
    [Serializable]
    public class MyDataTable : DataTable, ISerializable
    {
      ...
    }
