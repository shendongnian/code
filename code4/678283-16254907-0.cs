    private void RivalAlive()
    {
        DateTime S = DateTime.Now;
        while(DateTime.Now.Subtract(S).TotalSeconds < 600 && SmallHour !=5)
             System.Threading.Thread.Sleep(1000);
    }
