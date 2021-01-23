    bool logMessages = Convert.ToBoolean(ConfigurationManager.AppSettings["LogMessages"]);
    //other settings or whatever
    try
                {
                    SocketInitiator initiator;
                    QuickFix.SessionSettings settings = new QuickFix.SessionSettings(file);
                    MessageProcessor application = new MessageProcessor();
                    QuickFix.IMessageStoreFactory storeFactory = new QuickFix.FileStoreFactory(settings);
                    QuickFix.ILogFactory logFactory = new QuickFix.FileLogFactory(settings);
    
                    if (!logMessages)
                    {
    
                        initiator = new QuickFix.Transport.SocketInitiator(application, storeFactory, settings);
                    }
                    else
                    {
    
                        initiator = new QuickFix.Transport.SocketInitiator(application, storeFactory, settings, logFactory);
                    }
                   
    
                    application.MyInitiator = initiator;
    
    
                    initiator.Start();
                    while (!initiator.IsLoggedOn)
                    {
                        //wait until the initiator has logged on
                    }
                    //do stuff
                }
    catch
    {// exception handling code}
