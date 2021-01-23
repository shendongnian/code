    while(isPipeWorking)
                {
                    IAsyncResult asyncResult = namedPipeServerStream.BeginWaitForConnection(this.WaitForConnectionAsyncCallback, null);
                    Thread.Sleep(3*1000);
                    if (asyncResult.IsCompleted)
                        RestartPipeServer();
                }
