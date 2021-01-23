    class feedAllCinemas
    {
       ProgressBar m_ProgressBar;
       public feedAllCinemas(ProgressBar pbar)
       {
            m_ProgressBar = pbar;
       }
       void someMethod()
       {
             m_ProgressBar.Visibility = Visibility.Collapsed;
       }
    }
