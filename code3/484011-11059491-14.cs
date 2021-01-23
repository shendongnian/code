    public void Handle(TCommand command)
    {
        string xml = this.commandSerializer.ToXml(command);    
    
        Task.Factory.StartNew(() =>
        {
            var logger = 
                this.container.GetInstance<ILogger>();
            string xml = null;
        
            try
            {
                using (container.BeginTransactionScope())
                {
                    // must be created INSIDE the scope.
                    var handler = this.instanceCreator();
                    handler.Handle(command);
                }
            }
            catch (Exception ex)
            {
                // Don't let the exception bubble up, 
                // because we run in a background thread.
                this.logger.Log(ex, xml);
            }
        });
    }
