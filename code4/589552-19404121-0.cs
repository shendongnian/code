        private readonly IUIDispatcher _dispatcher;
        readonly Object _queueMonitor = new object();
        readonly Object _showMonitor = new object();
        private IAsyncOperation<IUICommand> _currentDialogOperation;
        readonly Queue<MessageDialog> _dialogQueue = new Queue<MessageDialog>();
        public async Task ShowAsync(string content)
        {
            var md = new MessageDialog(content);
            await showDialogAsync(md);
        }
        public async Task ShowAsync(string content, string caption)
        {
            var md = new MessageDialog(content, caption);
            await showDialogAsync(md);
        }
        public async Task<MessageDialogResult> ShowAsync(string content, MessageDialogType dialogType)
        {
            var messageDialogResult = await ShowAsync(content, null, dialogType);
            return messageDialogResult;
        }
        public async Task<MessageDialogResult> ShowAsync(string content, string caption, MessageDialogType dialogType)
        {
            var result = MessageDialogResult.Ok;
         
           
                var md = string.IsNullOrEmpty(caption) ?  new MessageDialog(content) : new MessageDialog(content, caption);
            switch (dialogType)
            {
                case MessageDialogType.Ok:
                    md.Commands.Add(new UICommand(ResWrapper.Strings["MessageDialogButtonOk"], command => result = MessageDialogResult.Ok));
                    md.CancelCommandIndex = 0;
                    md.DefaultCommandIndex = 0;
                    break;
                case MessageDialogType.OkCancel:
                    md.Commands.Add(new UICommand(ResWrapper.Strings["MessageDialogButtonOk"], command => result = MessageDialogResult.Ok));
                    md.Commands.Add(new UICommand(ResWrapper.Strings["MessageDialogButtonCancel"], command => result = MessageDialogResult.Cancel));
                    md.DefaultCommandIndex = 0;
                    md.CancelCommandIndex = 1;
                    break;
                case MessageDialogType.YesNo:
                    md.Commands.Add(new UICommand(ResWrapper.Strings["MessageDialogButtonYes"], command => result = MessageDialogResult.Yes));
                    md.Commands.Add(new UICommand(ResWrapper.Strings["MessageDialogButtonNo"], command => result = MessageDialogResult.No));
                      md.DefaultCommandIndex = 0;
                    md.CancelCommandIndex = 1;
                    break;
                case MessageDialogType.YesNoCancel:
                    md.Commands.Add(new UICommand(ResWrapper.Strings["MessageDialogButtonYes"], command => result = MessageDialogResult.Yes));
                    md.Commands.Add(new UICommand(ResWrapper.Strings["MessageDialogButtonNo"], command => result = MessageDialogResult.No));
                    md.Commands.Add(new UICommand(ResWrapper.Strings["MessageDialogButtonCancel"], command => result = MessageDialogResult.Cancel));
                    md.DefaultCommandIndex = 0;
                    md.CancelCommandIndex = 1;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("dialogType");
            }
            await showDialogAsync(md);
  
            return result;
        }
    
        /// <summary>
        /// Shows the dialogs, queued and one after the other.
        /// We need this as a workaround for the the UnauthorizedAcsess exception. 
        /// </summary>
        /// <param name="messageDialog">The message dialog.</param>
        /// <returns></returns>
        async Task showDialogAsync(MessageDialog messageDialog)
        {
            //Calls this function in a separated task to avoid ui thread deadlocks.
            await Task.Run(async () => 
            { 
                lock (_queueMonitor)
                {
                    _dialogQueue.Enqueue(messageDialog);
                }
                try
                {
                    while (true)
                    {
                        MessageDialog nextMessageDialog;
                        lock (_queueMonitor)
                        {
                            if (_dialogQueue.Count > 1)
                            {
                                Debug.WriteLine("MessageDialogService.cs | showDialogAsync | Next dialog is waiting for MessageDialog to be accessable!!");
                                Monitor.Wait(_queueMonitor); //unlock and wait - regains lock after waiting
                            }
                            nextMessageDialog = _dialogQueue.Peek();
                        }
                        var showing = false;
                        _dispatcher.Execute(async () =>  
                        {
                            try
                            {
                                lock (_showMonitor)
                                {
                                    showing = true;
                                    _currentDialogOperation = nextMessageDialog.ShowAsync();
                                }
                                await _currentDialogOperation;
                                lock (_showMonitor)
                                    _currentDialogOperation = null;
                            }
                            catch (Exception e)
                            {
                                Debug.WriteLine("MessageDialogService.cs | showDialogAsync | " + e);
                            }
                            lock (_showMonitor)
                            {
                                showing = false;
                                Monitor.Pulse(_showMonitor); //unlock and wait - regains lock after waiting
                            }
                        });
                      
                        lock (_showMonitor)
                        {
                            if (showing)
                            {
                                Debug.WriteLine("MessageDialogService.cs | showDialogAsync | Waiting for MessageDialog to be closed!!");
                                //we must wait here manually for the closing of the dialog, because the dispatcher does not return a waitable task.
                                Monitor.Wait(_showMonitor); //unlock and wait - regains lock after waiting
                            }
                        }
                        Debug.WriteLine("MessageDialogService.cs | showDialogAsync | MessageDialog  was closed.");
                        return true;
                    }
                }
                finally
                {
                    //make sure we leave this in a clean state
                    lock (_queueMonitor)
                    {
                        _dialogQueue.Dequeue();
                        Monitor.Pulse(_queueMonitor);
                    }
                }
            });
        }
        public void Close(string keyContent="")
        {
            try
            {
                if (keyContent.IsNullOrEmpty())
                {
                    lock (_showMonitor)
                    {
                        if (_currentDialogOperation == null) return;
                        _currentDialogOperation.Cancel();
                        _currentDialogOperation = null;
                    }
                }
                else
                {
                    var cancel = false;
                    lock (_queueMonitor)
                    {
                        if (_dialogQueue.Count == 0)
                            return;
                        var currentDialog = _dialogQueue.Peek();
                        Debug.WriteLine("MessageDialogService.cs | Close | {0}", currentDialog.Content);
                        if (currentDialog.Content == keyContent)
                        {
                            cancel = true;
                        }
                    }
                    if (!cancel) return;
                    lock (_showMonitor)
                    {
                        if (_currentDialogOperation == null) return;
                        _currentDialogOperation.Cancel();
                        _currentDialogOperation = null;
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("MessageDialogService.cs | Close | " + e);
            }
            
        }
