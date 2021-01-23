    new Thread(() =>
    {
        AutoResetEvent signal = new AutoResetEvent(false);
        while (reader.Read())
        {
            // Store scenario information
            int Id = (int)reader["ScenarioID"];
            string Data = reader["ScenarioData"].ToString();
            string Url = "http://google.com";
            // Initialize result information
            int HasSucceeded = 0;
            var screenshot = new Byte[] { };
            Action action = () =>
            {
                 webBrowser2.Tag = signal;
                 // Navigate to webBrowser
                 webBrowser2.Navigate(Url);
                 webBrowser2.DocumentCompleted -= WebBrowserDocumentCompleted;
                 webBrowser2.DocumentCompleted += WebBrowserDocumentCompleted;
            };
            webBrowser2.Invoke(action);
            signal.WaitOne();//Wait till it finishes
            // Do test
            TestScenarios(Url, HasSucceeded);
            // Take screenshot
            TakeScreenshot(screenshot);
            // Insert results
            InsertResults(Id, HasSucceeded, screenshot);
            // Mark scenario for deletion
            MarkScenario(Id);
        }
    }).Start();
        private void WebBrowserDocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs Url)
        {
            MessageBox.Show("Operation has completed!");
            ((AutoResetEvent)((WebBrowser)sender).Tag).Set();
        }
