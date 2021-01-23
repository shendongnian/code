    private void RepeatCall(int numberOfCalls, Action unitOfWork)
    {
        for (int i = 1; i <= numberOfCalls; i++)
            {
            try
            {
                unitOfWork();
            }
            catch (...)
            {
                // decide which exceptions/faults should be retried and 
                // which should be thrown
                // and always throw when i == numberOfCalls
            }
         }
     }
