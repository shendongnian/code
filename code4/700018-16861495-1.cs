        private void Button_Click(object sender, EventArgs e)
        {
            var proxy = new WebServiceProxy();
            // Tell the proxy object that when the web service
            // call completes we want it to invoke our custom
            // handler which will process the result for us.
            proxy.getRecordsCompleted += this.HandleGetRecordsCompleted;
            // Make the async call. The UI thread will not wait for 
            // the web service call to complete. This method will
            // return almost immediately while the web service
            // call is happening in the background.
            // Think of it as "scheduling" a web service
            // call as opposed to actually waiting for it
            // to finish before this method can progress.
            proxy.getRecordsAsync("USERNAME", new[] { 1, 2, 3, 4 });
            this.Button.Enabled = false;
        }
        /// <summary>
        /// Handler for when the web service call returns.
        /// </summary>
        private void HandleGetRecordsCompleted(object sender, getRecordsCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.ToString());
            }
            else
            {
                record[] result = e.Result;
                // Run your LINQ code on the result here.
            }
            this.Button.Enabled = true;
        }
