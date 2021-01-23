        using (TransactionScope scope = new TransactionScope())
        {
            for (int i = _from; i <= _to; i++)
            {
                if (condition)
                {
                    // Do the do
                    continue;
                }
            }
        }
