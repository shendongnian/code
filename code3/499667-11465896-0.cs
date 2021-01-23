    public class DataSource : INotifyPropertyChanged
    {
    public string AssignedTo
    {
    get;set;
    }
...
    public bool SysGenerated
    {
    get;set;
    }
    public string UserID
    {
    get;set;
    }
    public DataSource(string jsonContent)
    {
    // use reflection to create the class
    }
    }
