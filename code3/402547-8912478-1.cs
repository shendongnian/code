    public void method() {
        var handler = new ActionWaitHandler(2, OnActionsComplete);
                
        _model.GetMyTypeList(list =>
        {
            MyTypeList.AddRange(list);
            handler .Signal();
        });
    
        _model.GetStigTypeList(list =>
        {
            StigTypeList.AddRange(list);
            handler .Signal();
        });
    }
    
    public void OnActionsComplete()
    {
        dosomething;
    }
