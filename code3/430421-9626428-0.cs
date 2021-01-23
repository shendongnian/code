    public void GetData<T>(string CSVPath)
    {
        var engine = new FileHelperEngine(typeof(T));
        _Data = engine.ReadFile(CSVPath) as T;
        if (_Data != null)
        {
            //correct type, do the rest of your stuff here
        }
    }
