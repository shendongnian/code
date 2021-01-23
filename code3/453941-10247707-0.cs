    private static List<T> GetObjectList(DateTime mostRecentProcessedReadTime)
    {
        using (MesReportingDal data = new MesReportingDal<T>())
        {
            return data.Get(mostRecentProcessedReadTime);        
        }
    }
