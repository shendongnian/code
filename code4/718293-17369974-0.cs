    private _lastWriteDate = DateTime.MinValue;
    public void LogIt(string message)
    {
        var nowDate = DateTime.Now.Date;
        if (nowDate != _lastWriteDate)
        {
            // close current log and open a new one
        }
        WriteLog(message);
        _lastWriteDate = nowDate;
    }
