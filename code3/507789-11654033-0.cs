        private void ConsumeTransactions()
        {
            while (!_bin.IsCompleted)
            {
                Transaction item;
                if (_bin.TryTake(out item, TimeSpan.FromMilliseconds(100))
                {
                    // consume the item
                }
            }
        }
