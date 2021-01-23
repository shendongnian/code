        private static void CalculateDetails(int id, List<ErrorType> problematicIds)
        {
            try
            {
                // Handle deadlocks
                DeadlockRetryHelper.Execute(() => CalculateDetails(id));
            }
            catch (Exception e)
            {
                // Too many deadlock retries (or other exception). 
                // Record so we can diagnose problem or retry later
                problematicIds.Add(new ErrorType(id, e));
            }
        }
