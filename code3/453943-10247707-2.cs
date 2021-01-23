    private static List<T> GetObjectList(DateTime mostRecentProcessedReadTime)
    {
        using (var data = new MesReportingDal<T>())
        {
            return data.Get(mostRecentProcessedReadTime);        
        }
    }
