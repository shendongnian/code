    public class EFRetryPolicy : DbExecutionStrategy
    {
        public EFRetryPolicy() : base()
        {
        }
        //Keep this constructor public too in case it is needed to change defaults of exponential back off algorithm.
        public EFRetryPolicy(int maxRetryCount, TimeSpan maxDelay): base(maxRetryCount, maxDelay)
        {
        }
        protected override bool ShouldRetryOn(Exception ex)
        {
            
            bool retry = false;
            SqlException sqlException = ex as SqlException;
            if (sqlException != null)
            {
                int[] errorsToRetry =
                {
                    1205,  //Deadlock
                    -2,    //Timeout
                };
                if (sqlException.Errors.Cast<SqlError>().Any(x => errorsToRetry.Contains(x.Number)))
                {
                    retry = true;
                }
               
            }          
            return retry;
        }
    }
