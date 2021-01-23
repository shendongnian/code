    public Connection(bool getParam = false)
        {
           if (getParam)
           {
              _param = GetConnection(parameter);
           }
        }
