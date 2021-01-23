    private void Form1_Load(object sender, EventArgs e)
    {
        Thread thread = new Thread(MethodThread);
        thread.Start(SynchronizationContext.Current);
    }
    
    private void MethodThread(Object syncronizationContext)
    {
        ((SynchronizationContext)syncronizationContext).Send(CloseForm,null);
    }
    
    private void CloseForm(Object state)
    {
        Close();
    }
