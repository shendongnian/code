    Control activeControl;
    private void start_new_thread()
    {
        active = Form1.ActiveForm;
        // start work under thread
    }
    private void work_under_thread(object state)
    {
    
        //blocking works
        // update here
        UpdateText("My Monitor (Last Updated " + DateTime.Now.ToString("HH:mm:ss tt") + ")", activeControl);
    
    }
