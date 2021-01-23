        private void UpdateUI(string item) 
        {
            if (Thread.CurrentThread.IsBackground) 
            {
                listEvents.Dispatcher.Invoke(new Action(() => //dispatch to UI Thread
                {
                    listEvents.Items.Add(item);
                }));
            }
            else
            {
                listEvents.Items.Add(item);
            }
        }
