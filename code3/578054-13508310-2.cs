    public void AddData(Action<CompletedEventArgs, Exception> callback, IPVWorkflowService.CreateEditDeletePriceSourceRequest request)
            {
                _workflowProxy.CreateEditDeletePriceSourceAsync(request, callback);
                _workflowProxy.CreateEditDeletePriceSourceCompleted+=new EventHandler<CreateEditDeletePriceSourceCompletedEventArgs>(_workflowProxy_CreateEditDeletePriceSourceCompleted); 
            }
