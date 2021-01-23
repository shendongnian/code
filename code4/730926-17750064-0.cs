        private void OnModulePartInvoked(IModulePart modulePart)
        {
            try
            {
                this.IsAdornerVisible = true;
                RefreshCallback();
                var controller = modulePart.StartControllerName;
                var action = modulePart.StartAction;
                var viewName = this.verifier.GetViewName(controller, action);
                Messenger.Default.Send(new AddDocumentMessage(controller, action) { Title = viewName }, this.MessageToken);
            }
            finally
            {
                this.IsAdornerVisible = false;
            }
    }
