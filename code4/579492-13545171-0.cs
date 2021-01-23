    public static WordDataSource Instance
    {
        get
        {
            if (_dataSoruce == null)
            {
                _dataSoruce = new WordDataSource();
             }
             return _dataSoruce;
         }
    }
