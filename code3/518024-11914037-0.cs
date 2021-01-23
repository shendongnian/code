    public enum mytype 
    {
        Info,
        Error,
        Warning,
        Debug,
        Success
    }
    public List<mytype> lst = Enum.GetValues(typeof(mytype))
                                  .Cast<mytype>().ToList();
