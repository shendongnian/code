    private static readonly IDateTimeService datetimeService;
    public MyController (IDateTimeService datetimeService)
    {
       this.datetimeService = datetimeService;
    }
    public void SomeMethod()
    {
         var date = datetimeService.GetDate();
         ...
    }
