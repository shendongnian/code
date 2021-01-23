    class chartscopier
    {
     public static event EventHandler<ChartCopyProgressEventArgs> Changed;
     public static void CopyGraph(object data)
     {
     ...
     if (Changed != null)
     {
       var args = new ChartCopyProgressEventArgs();
       args.ElapsedTime = elapsedTime;
       Changed(null, args);
     }
     }
    }
