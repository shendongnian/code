    public static void ProcessEnMasse(System.DateTime fromDate, DateTime endDate)
        {
            System.Threading.ThreadPool.SetMaxThreads(10, 10);
            for (System.DateTime d = fromDate; d <= endDate; d = d.AddDays(1))
            {
                System.DateTime newD = d;
                System.Threading.ThreadPool.QueueUserWorkItem
                    (new System.Threading.WaitCallback(day => ProcessOneDay(newD)));
            }
        }
