    private static ConcurrentStack<Tuple<DateTime, Exception, String, bool, bool>> ErrorStack = new ConcurrentStack<Tuple<DateTime, Exception, String, bool, bool>>();
    private static bool ExceptionHandlingTerminated = false;
    private static bool ErrorBeingHandled = false; //Only one Error can be processed at a time
    public static void HandleError(Exception ex, bool showMsgBox) { HandleError(ex, "", showMsgBox, true); }
    public static void HandleError(Exception ex, string extraInfo, bool showMsgBox) { HandleError(ex, extraInfo, showMsgBox, true); }
    public static void HandleError(Exception ex, string extraInfo = "", bool showMsgBox = true, bool resetApplication = true)
    {
        if( ExceptionHandlingTerminated || App.Current == null) return;
        if( ErrorBeingHandled )
        {   //Queue up this error, it'll be handled later. Don't bother if we've already queued up more than 10 errors, we're just going to be terminating the application in that case anyway.
            if( ErrorStack.Count < 10 )
                ErrorStack.Push(new Tuple<DateTime, Exception, String, bool, bool>(DateTime.Now, ex, extraInfo, showMsgBox, resetApplication)); //Thread safe tracking of how many simultaneous errors are being thrown
            return;
        }
        ErrorBeingHandled = true;
        try
        {
            if( Thread.CurrentThread != Dispatcher.CurrentDispatcher.Thread )
            {
                ErrorBeingHandled = false;
                Invoke_HandleError( ex, extraInfo, showMsgBox, resetApplication );
                return;
            }
            if( ErrorStack.Count >= 5 )
            {
                ExceptionHandlingTerminated = true;
                Tuple<DateTime, Exception, String, bool, bool> errParams;
                String errQueue = String.Concat(DateTime.Now.ToString("hh:mm:ss.ff tt"), ": ", ex.Message, "\n");
                while( ErrorStack.Count > 0 )
                {
                    if( ErrorStack.TryPop(out errParams) )
                    {
                        errQueue += String.Concat(errParams.Item1.ToString("hh:mm:ss.ff tt"), ": ", errParams.Item2.Message, "\n");
                    }
                }
                extraInfo = "Too many simultaneous errors have been thrown in the background:";
                throw new Exception(errQueue);
            }
            if( !((App)App.Current).AppStartupComplete )
            {   //We can't handle errors the normal way if the app hasn't started yet.
                extraInfo = "An error occurred before the application could start." + extraInfo;
                throw ex;
            }
            if( resetApplication )
            {
                ((MUSUI.App)App.Current).ResetApplication();
            }
            if( showMsgBox )
            {
                //(removed)... Prepare Error message
                //IF the UI is processing a visual tree event (such as IsVisibleChanged), it throws an exception when showing a MessageBox as described here: http://social.msdn.microsoft.com/forums/en-US/wpf/thread/44962927-006e-4629-9aa3-100357861442
                //The solution is to dispatch and queue the MessageBox. We must use BeginInvoke because dispatcher processing is suspended in such cases.
                Dispatcher.CurrentDispatcher.BeginInvoke((Action<Exception, String>)delegate(Exception _ex, String _ErrMessage)
                {
                    MessageBox.Show(App.Current.MainWindow, _ErrMessage, "MUS Application Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    ErrorHandled(_ex); //Release the block on the HandleError method and handle any additional queued errors.
                }, DispatcherPriority.Background, new object[]{ ex, ErrMessage });
            }
            else
            {
                ErrorHandled(ex);
            }
        }
        catch( Exception terminatingError )
        {
            ExceptionHandlingTerminated = true;
            //A very serious error has occurred, such as the application not loading, and we must shut down.
            Dispatcher.CurrentDispatcher.BeginInvoke((Action<String>)delegate(String _fatalMessage)
            {
                MessageBox.Show(_fatalMessage, "Fatal Error", MessageBoxButton.OK, MessageBoxImage.Stop);
                if( App.Current != null ) App.Current.Shutdown(1);
            }, DispatcherPriority.Background, new object[] { fatalMessage + "\n" + terminatingError.Message });
        }
    }
    //The set of actions to be performed when error handling is done.
    private static void ErrorHandled(Exception ex)
    {
        ErrorBeingHandled = false;
        //If other errors have gotten queued up since this one was being handled, or remain, process the next one
        if(ErrorStack.Count > 0)
        {
            if( ExceptionHandlingTerminated || App.Current == null) return;
            Tuple<DateTime, Exception, String, bool, bool> errParams;
            //Pop an error off the queue and deal with it:
            ErrorStack.TryPop(out errParams);
            HandleError(errParams.Item2, errParams.Item3, errParams.Item4, errParams.Item5);
        }
    }
    //Dispatches a call to HandleError on the UI thread.
    private static void Invoke_HandleError(Exception ex, string extraInfo, bool showMsgBox, bool resetApplication)
    {
        ((App)App.Current).Dispatcher.BeginInvoke((Action<Exception, string, bool, bool>)
            delegate(Exception _ex, string _extraInfo, bool _showMsgBox, bool _resetApplication)
            {
                ErrorHandled(_ex); //Release the semaphore taken by the spawning HandleError call
                HandleError(_ex, _extraInfo, _showMsgBox, _resetApplication);
            }, DispatcherPriority.Background, new object[] { ex, extraInfo, showMsgBox, resetApplication });
    }
