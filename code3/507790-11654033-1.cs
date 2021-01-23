        private void ConsumeTransactions()
        {
            // loop until consumer marked completed, or cancellation token set
            while (!_bin.IsCompleted && !_tokenSource.Token.IsCancelRequested)
            {
                Transaction item;
                // try to take item for 100 ms, or until cancelled 
                if (_bin.TryTake(out item, 100, _tokenSource.Token)
                {
                    // consume the item
                }
            }
        }
