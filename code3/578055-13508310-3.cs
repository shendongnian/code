        void _workflowProxy_CreateEditDeletePriceSourceCompleted(object sender, CreateEditDeletePriceSourceCompletedEventArgs e)
        {
            try
            {
                this.dispatcher.BeginInvoke((Action)(() =>
                {
                    (e.UserState as Action<CompletedEventArgs, Exception>)(e, null);
                }));
            }
            catch (Exception ex)
            {
                this.dispatcher.BeginInvoke((Action)(() =>
                {
                    (e.UserState as Action<CompletedEventArgs, Exception>)(e, ex);
                }));
            }
            finally
            {
                _workflowProxy.CreateEditDeletePriceSourceCompleted -= _workflowProxy_CreateEditDeletePriceSourceCompleted;
                _workflowProxy = null;
            }
        }
