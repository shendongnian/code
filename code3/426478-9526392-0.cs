    public void Log(String message, params object[] args)
    {
        DateTime datet = DateTime.Now;
        if (sw == null)
        {
            sw = new StreamWriter(strPathName, true);
        }
        sw.Write(String.Format(message,args));
        sw.Flush();
    }
