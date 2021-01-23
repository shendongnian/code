    class DialogResultReference
    {
        internal DialogResult DialogResult { get; set; }
    }
    class YourClass
    {
        static void ShowMessageBox(object dialogResultReference)
        {
            var drr = (DialogResultReference)dialogResultReference;
            drr.DialogResult = MessageBoxEx.Show("Yes or no?", "Continue?",   MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
        }
        
        // ... You just remove dr from the class
        SynchronizationContext synchContext;
        //in main forms constructor
        {
            ...
            synchContext = AsyncOperationManager.SynchronizationContext;
        }
        void workerThread(object obj, DoWorkEventArgs args)
        {
            var drr = new DialogResultReference();
            sc.Send(YourClass.ShowMessageBox, drr);
        }
    }
