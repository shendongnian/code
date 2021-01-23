    if (m_contextWindow == null)
    {   
        System.Threading.Thread newWindowThread = new System.Threading.Thread(new ThreadStart( () =>
        {
            // Create and show the Window
            m_contextWindow = new ContextWindow();
            m_contextWindow.DataContext = this;                            
            m_contextWindow.Show();
            // Start the Dispatcher Processing
            System.Windows.Threading.Dispatcher.Run();
        }));
        
        // Set the apartment state
        newWindowThread.SetApartmentState(ApartmentState.STA);
        // Make the thread a background thread
        newWindowThread.IsBackground = true;
        // Start the thread
        newWindowThread.Start();
    }
    else
    {                     
        this.m_contextWindow.Dispatcher.Invoke(new ThreadStart(() => 
        {
            m_contextWindow.DataContext = this;
            if (m_contextWindow.Visibility == System.Windows.Visibility.Collapsed
             || m_contextWindow.Visibility == System.Windows.Visibility.Hidden)
                m_contextWindow.Visibility = System.Windows.Visibility.Visible;
        }));                            
    }
