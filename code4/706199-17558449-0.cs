    private void SetTimer(int time)
            {
                if (!TimerEnabled)
                {
                    return;
                }
                else
                {
                    if (DelayTimer != null)
                    {
                        DelayTimer.Cancel();
                        DelayTimer = null;
                    }
    
                    //the timeout 
                    TimeSpan delay = TimeSpan.FromSeconds(time);
    
                    bool completed = false;
    
                    DelayTimer = ThreadPoolTimer.CreateTimer(
                        (source) =>
                        {    
                            // 
                            // Update the UI thread by using the UI core dispatcher.
                            // 
                            Dispatcher.RunAsync(
                                     CoreDispatcherPriority.High,
                                     () =>
                                     {
                                         // 
                                         // UI components can be accessed within this scope.
                                        //THIS CODE GETS EXECUTED WHEN TIMER HAS FINISHED
    
                                     });
    
                            completed = true;
                        },
                        delay,
                        (source) =>
                        {
                            // 
                            // TODO: Handle work cancellation/completion.
                            // 
    
    
                            // 
                            // Update the UI thread by using the UI core dispatcher.
                            // 
                            Dispatcher.RunAsync(
                                CoreDispatcherPriority.High,
                                () =>
                                {
                                    // 
                                    // UI components can be accessed within this scope.
                                    // 
    
                                    if (completed)
                                    {
                                        // Timer completed.
                                    }
                                    else
                                    {
                                        // Timer cancelled.
                                    }
    
                                });
                        });
                }
            }
