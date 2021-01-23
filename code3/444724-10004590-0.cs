    public Result SomeMethod()
    {
        Popup popup = new Popup();
        bool called = false;
        Result result = null;
        popup.Closed += (args) => {
            called = true;
            result = args.Result;
        }
        while(!called) ;
        return result;
    }
