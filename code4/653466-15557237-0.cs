    public String ChatToServer(string texttoServer) // send some text to the server
            {
    
                try
                {
                    Logging.Write_To_Log_File("Entry", MethodBase.GetCurrentMethod().Name, "", "", "", 1);
                    // Some extemely important prechecks .....
                    System.Threading.Thread thread = new System.Threading.Thread(DoWork);
                    thread.Start();
                    //........
                    return "success";
    
                    // Dont care now if client disconnects but lets give them some updates as progress happens if they are still connected
    
                }
                catch (Exception ex)
                {
                    return "error";
                }
            }
    
            void DoWork()
            {
                IMyContractCallBack callback = OperationContext.Current.GetCallbackChannel<IMyContractCallBack>();
                // Some processing .....
                callbackmethod("20% complete", callback);
                // Some processing .....
                callbackmethod("40% complete", callback);
                // Some processing .....
                callbackmethod("60% complete", callback);
                // Some processing .....
                callbackmethod("80% complete", callback);
                // Some processing .....
                callbackmethod("100% complete", callback);
    
            }
