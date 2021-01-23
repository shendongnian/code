        Function() // method to be called after regular interval in Timer
        {
            // lengthy process, i.e. data fetching and processing etc.
            // here comes the UI update part
            Dispatcher.Invoke((Action)delegate() { /* update UI */ });
        }
