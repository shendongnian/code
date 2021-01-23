        public delegate TResponse DoXDelegate<in TRequest, out TResponse>(TRequest request);
        public static TResponse DoGen<TRequest, TResponse>(TRequest requestObj, DoXDelegate<TRequest, TResponse> method)
            where TRequest : class
            where TResponse : class
        {
            // lots of common code for logging & preperation
            var worker = GetWorker();
            /*var mi = worker.GetType().GetMethod(methodname);
            var result = mi.Invoke(worker, new Object[] { requestObj });
            return result as TResponse;*/
            return method.Invoke(requestObj);
        }
