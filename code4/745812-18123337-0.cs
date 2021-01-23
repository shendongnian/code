    var timer = new System.Threading.Timer(new TimerCallback(YourMethod)), null, 40000, Timeout.Infinite);
    private void YourMethod()
    {
        //Magic
        timer.Change(40000, Timeout.Infinite);
    }
