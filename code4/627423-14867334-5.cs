    private List<Type> _systemTypes;
    public List<Type> SystemTypes
    {
        get
        {
            if (_systemTypes == null)
            {
                _systemTypes = Assembly.GetExecutingAssembly().GetType().Module.Assembly.GetExportedTypes().ToList();
            }
            return _systemTypes;
        }
    }
    public static string ConvertToCsv<T>(IEnumerable<T> items)
    {
        foreach (T item in items.Where(i => SystemTypes.Contains(i.GetType())))
        {
             // is system type
        }
    }
