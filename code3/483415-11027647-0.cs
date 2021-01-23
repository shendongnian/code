    int[] times = new int[] { 10000, 14000, 17000 };
    foreach (int time in times)
    {
    System.Threading.Timer t = new System.Threading.Timer(MyTimerCallback, null, time, 0);
    ...
    }
                
    private void MyTimerCallback(object state)
    {
      //Do some awesome stuff
    }
