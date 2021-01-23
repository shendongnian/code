    var startTimeSpan = TimeSpan.Zero;
    var periodTimeSpan = TimeSpan.FromMinutes(5);
    var timer = new System.Threading.Timer((e) =>
    {
        MyMethod();   
    }, null, startTimeSpan, periodTimeSpan);
