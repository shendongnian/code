    private static void TaskGestioneCartelle()
    {            
        Task.Factory.StartNew(() => GeneraListaCartelle())
            .ContinueWith(t => GeneraListaCartelleCompletata()
            , CancellationToken.None
            , TaskContinuationOptions.None
            , TaskScheduler.FromCurrentSynchronizationContext());
    }
    private static void GeneraListaCartelle()
    {
        //No sleep could block the thread UI because the task is being executed on a different Thread
        Debug.WriteLine("GeneraListaCartelle " + Thread.CurrentThread.ManagedThreadId);
        Thread.Sleep(4000);            
        mainForm.Invoke(new Action(() => bla.Text = "uno due tre, Genera Lista!"));            
    }
    private static void GeneraListaCartelleCompletata()
    {
        //This is begin executed on the UI thread
        Debug.WriteLine("GeneraListaCartelleCompletata " + Thread.CurrentThread.ManagedThreadId);
        Task.Factory.StartNew(() => CopiaCartelle())
            .ContinueWith(t => CopiaCartelleCompletato()
            , CancellationToken.None
            , TaskContinuationOptions.None
            , TaskScheduler.FromCurrentSynchronizationContext());
    }
    private static void CopiaCartelle()
    {
        //This is begin executed on the UI thread (doesn't even show in the form 'cause the thread is blocked)
        Debug.WriteLine("CopiaCartelle " + Thread.CurrentThread.ManagedThreadId);
        Thread.Sleep(4000);   
        mainForm.Invoke(new Action(() => bla.Text = "Copia Cartelle \\o"));            
    }
    private static void CopiaCartelleCompletato()
    {
        //This is begin executed on the UI thread
        Debug.WriteLine("CopiaCartelleCompletato " + Thread.CurrentThread.ManagedThreadId);
        Thread.Sleep(4000);   
        mainForm.Invoke(new Action(() => bla.Text = "Completato!"));
        //Stops blocking the UI thread
    }
