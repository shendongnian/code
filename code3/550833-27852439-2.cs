        static async void FireAndForget(this Task task)
        {
           try
           {
                await task;
           }
           catch (Exception e)
           {
               // log errors
           }
        }
