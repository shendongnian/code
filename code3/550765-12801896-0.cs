    AutoResetEvent[] autoResetEvents;
    main()
    {
        autoResetEvent = new AutoResetEvent[dtPP.Rows.Count];
        Parallel.For(0, dtPP.Rows.Count, i =>
        {
             string f = "";
             WebClient client = new WebClient();
             client.DownloadDataCompleted += new DownloadDataCompletedEventHandler(client_DownloadDataCompleted);
             lock (dtPP.Rows[i])
             {
                  f = dtPP.Rows[i]["pp_url"].ToString();
             }
             Object[] parameters = new Object[2];
             autoResetEvents[i] = new AutoResetEvent(false);
             parameters[0] = i;
             parameters[1] = autoResetEvent[i];
    
             client.DownloadDataAsync(new Uri(f), parameters);
        });
        WaitHandle.WaitAll(autoResetEvents);
        DoSomething();
     }
    
        void client_DownloadDataCompleted(object sender, DownloadDataCompletedEventArgs e)
        {
            Object[] parameters = (object[])e.UserState;
            autoResetEvent = (AutoResetEvent)parameters[1];
            int h = (int)parameters[0];
            page = (int)e.UserState;
            myString = enc.GetString(e.Result);
            lock (matUrlFharsing[h])
            {
                lock (dtPP.Rows[h])
                {
                    //save in mat
                    matUrlFharsing[h] = Pharsing.CreateCorrectHtmlDoc(myString);
                }
            }
            autoResetEvent.Set();
        }
