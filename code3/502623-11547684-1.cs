    [WebMethod]
    public static string GetProgressStatus(string ProcessID)
    {
        string completed_process = "0";
        if (_lst.Count > 0)
        {
            int i = 0;
            for (i = 0; i <= _lst.Count - 1; i++)
            {
                if (_lst[i].vinfo.ProcessID == ProcessID)
                {
                    completed_process = Math.Round(_lst[i].vinfo.ProcessingCompleted, 2).ToString();
                }
            }
        }
        return completed_process;
    }
