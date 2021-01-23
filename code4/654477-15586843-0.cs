    public string getMyBook(string bookName)
    {
        Servo.ServoClient svc = new ServoClient();
        svc.GetBookAsync(bookName);
        var o = Observable.FromEventPattern<GetBookCompletedEventArgs>(svc, "GetBookCompleted");
        return o.First().EventArgs.Result;
    }
