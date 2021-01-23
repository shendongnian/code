    NSTimer timer;
    void StartTimer()
    {
        using (var pool = new NSAutoreleasePool())
        {
            timer = NSTimer.CreateScheduledTimer(_survey.Timeout, delegate { 
                _survey.CurrentQuestion = 1;
                _survey.Responses.Clear();
                QuestionController qvc = new QuestionController(_survey);
                this.NavigationController.PushViewController(qvc, false);       
            });
            NSRunLoop.Current.Run();
        }
    }
    void StopTimer ()
    {
        timer.Invalidate ();
        timer.Dispose ();
        timer = null;
    }
