        private Window activeRequestBox;
        // invoked on domain thread
        public void AskUserToPerformDetectableAction(
            string message, Action userAbortCallback,
            out Action actionDetectedCallback)
        {
            OpenDetectableActionRequestBox(message, userAbortCallback);
            actionDetectedCallback = CloseRequestBox;
        }
        private void OpenDetectableActionRequestBox(
            string message, Action userAbortCallback)
        {
            Action openWindow =
                () =>
                {
                    activeRequestBox = new DetectableActionRequestBox(
                         message, userAbortCallback);
                    activeRequestBox.Closed += RequestBoxClosedHandler;
                    activeRequestBox.Show();
                };
            this.Dispatcher.Invoke(openWindow);            
        }
        // invoked on request box thread
        private void RequestBoxClosedHandler(object sender, EventArgs e)
        {
            activeRequestBox = null;
        }
        // invoked on domain thread
        private void CloseRequestBox()
        {
            if (activeRequestBox != null)
            {
                Action closeWindow =
                    () => activeRequestBox.Close();
                this.Dispatcher.Invoke(closeWindow);
            }
        }
