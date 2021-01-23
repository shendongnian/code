    if (Listener != null)
    {
    	m_dispatcherListener.Invoke((Action)delegate()
    	{
    		Listener.OnTerminateCompleted((int)TerminateStatus.Completed);
    	});
    }
