    public static DateTime PauseForMilliSeconds(int MilliSecondsToPauseFor)
    {
        System.DateTime ThisMoment = System.DateTime.Now;
        System.TimeSpan duration = new System.TimeSpan(0, 0, 0, 0, MilliSecondsToPauseFor);
        System.DateTime AfterWards = ThisMoment.Add(duration);
                
        while (AfterWards >= ThisMoment)
        {
            System.Windows.Forms.Application.DoEvents();
            ThisMoment = System.DateTime.Now;
        }
                
        return System.DateTime.Now;
    }
