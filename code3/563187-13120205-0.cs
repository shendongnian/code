    public Class2(out Data maindata) 
    {
        changeData();
        maindata = data;
    }
    private Data changeData()
    {
        Data test = new Data();
        test.Name = "newData";
        data = test;
    }
