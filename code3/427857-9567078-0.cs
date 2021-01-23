      public static AResponse DoA2(ARequest aRequest)
      {
        return DoGen<ARequest, AResponse>(aRequest, worker => worker.DoA);
      }
      public static BResponse DoB2(BRequest bRequest)
      {
        return DoGen<BRequest, BResponse>(bRequest, worker => worker.DoB); 
      }
      public static TResponse DoGen<TRequest, TResponse>(TRequest requestObj, 
           Func<IWorker, Func<TRequest, TResponse>> methodRef)
        where TRequest : class
        where TResponse : class
      {
        // lots of common code for logging & preparation 
        var worker = GetWorker();
        var method = methodRef(worker);
        return method(requestObj);
      }
