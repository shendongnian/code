    private ConcurrentBag<Metrics> allMetrics = new ConcurrentBag<Metrics>();
    private int DegreeOfParallelism { get { return Convert.ToInt32(ConfigurationManager.AppSettings["DegreeOfParallelism"].ToString()); } }
    
    var lOptions = new ParallelOptions() { MaxDegreeOfParallelism = DegreeOfParallelism };
    Parallel.ForEach(RequestBag, lOptions, (lItem, loopState) =>
    {
        if (!string.IsNullOrEmpty(lItem.XmlRequest))
        {
            try
            {
                var Metrics = new Metrics();
                var Stopwatch = new Stopwatch();
                Stopwatch.Start();
                ObjRef = new Object();
                lItem.XmlRequest = ObjRef.GetDecision(Username, Password);
                Stopwatch.Stop();
                Metrics.ElapsedTime = string.Format("{0:0.00}", Stopwatch.Elapsed.TotalSeconds);
    
                Stopwatch.Restart();
                if (!string.IsNullOrEmpty(DBConnectionString))
                {
                    DataAccess = new DataAccess2(DBConnectionString);
                    DataAccess.WriteToDB(lItem.XmlRequest);  
                }
                Stopwatch.Stop();
                Metrics.DbFuncCallTime = string.Format("{0:0.00}", Stopwatch.Elapsed.TotalSeconds); 
            }
            catch (Exception pEx)
            { 
                KeepLog(pEx);
                Metrics.HasFailed = true;
            }
            finally
            {
                ProcessedIdsBag.Add(lItem.OrderId);
                Metrics.ProcessedOrderId = lItem.OrderId;
                Metrics.DegreeOfParallelism = DegreeOfParallelism;
                Metrics.TotalNumOfOrders = NumberOfOrders;
                Metrics.TotalNumOfOrdersProcessed = ProcessedIdsBag.Count;
                pBackgroundWorker.ReportProgress(Metrics.GetProgressPercentage(NumberOfOrders, ProcessedIdsBag.Count), Metrics);
    
                RequestBag.TryTake(out lItem);
                allMetrics.add(Metrics);
            }
        }
    });
    
    // Aggregate everything in AllMetrics here
