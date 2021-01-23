    private void LoadinDatagrid()
    {   
        IsBusy = true;
        GetResult.Completed += new EventHandler(GetResult_Completed);       
        GetResult = DomainContext.Current.Load(GetSomething1Query());
        GetResult = DomainContext.Current.Load(GetSomething2Query());
        GetResult = DomainContext.Current.Load(GetSomething3Query());         
              
    }
    void GetResult_Completed(object sender, EventArgs e)
    {
       if(e.result!=null){
        if(e.result.x=="GetSomething1")
        GetSomething1 = DomainContext.Current.Something1;
        else if(e.result.x=="GetSomething2")
        GetSomething2 = DomainContext.Current.Something2;
        else if(e.result.x=="GetSomething3")
        GetSomething3 = DomainContext.Current.Something3;
        //
        //Because when returned 1st data then stop eventhandler.
        //GetResult.Completed -= new EventHandler(GetResult_Completed);
        //
       }
        IsBusy = false;     
    }
