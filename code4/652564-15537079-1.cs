                  try
                    {
                        var result = makeExternalHttpRequest();
                        if(stopwatch.Elapsed > SomeUnreasonableTimespan) 
                              logger.Warn("Task exceeded reasonable execution period." + TaskData);
                        if (!token.IsCancellationRequested)
                        {
                            return result;
                        }
                    }catch(Exception exception)
                    {
                    }
                    return null;
