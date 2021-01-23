    void client_GetItemsCompleted(object sender, GetItemsCompletedEventArgs e)
    {
        try {
           /* .... */
        }
        finally {
            client.GetItemsCompleted -= 
                new EventHandler<GetItemsCompletedEventArgs>(client_GetItemsCompleted);
        }
    }
