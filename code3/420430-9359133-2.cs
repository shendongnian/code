    /// <summary>
    /// Create a log entry in the log file and then Fire an event for the log message to be handled
    /// </summary>
    /// <param name="category">The category to log the message against</param>
    /// <param name="args"> Message logging arguments used by the event</param>
    public void WriteLine(Category category, MessageEventArgs args)
    {
        // Ensure that the category specified exists in the array list
        if( this.m_CategoryList.Contains( category ) )
        {
            // Ensure the category is active 
            if(category.Active == true)
            {
                if(!category.ExcludeFromLogFile)
                {
                    // Try and log the message to the log file
                    this.WriteLineToFile( category, args );
                }
    
                // Ensure an event handler has been assigned
                if(MessageEvent != null)
                {
                    // This message event is handled by the UI thread for updating screen components.
                    MessageEvent(category, args);
                }
            }
        }
    }
