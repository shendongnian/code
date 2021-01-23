    Task outer = FooAsync()
        .Then(BarAsync())
        .Then(FubarAsync());
    
    outer.ContinueWith(t => {
        if(t.IsFaulted) {
            //handle exception
        }
    });
