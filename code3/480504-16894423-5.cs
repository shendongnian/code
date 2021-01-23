        protected override void OnHandleCreated(EventArgs e)
        {
            TextBoxTraceListener tbtl = new TextBoxTraceListener(TheTextBox);
            Debug.Listeners.Add(tbtl);
            Debug.WriteLine("Testing Testing 123");
        }
