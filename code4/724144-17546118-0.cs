    for(var i = 0; i < 3; i++)
    {
        Thread.Sleep(1000)
        Task.Wait(Task.StartNew(() =>
            {
                //Do Something
                if (myCondition==true)
                {
                    // Do Something
                    // Or Change Value of a Property! anything that shows it
                    // meets the condition.
                }
            });
    }
