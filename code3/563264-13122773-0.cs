    private DataClass dataClass;
    public DataClass DataClass
    {
        get
        {
            if(dataClass  == null)
            {
                 dataClass = new DataClass();
            }
            return dataClass;
        }
    }
