    public void PostDoFireAndForget() // and NOT public Task PostDoFireAndForget()
        {
            Task.Factory.StartNew
                (() =>
                    {
                        // ... start the operation here
                        // make sure you have an exception handler!!
                    }
                );
        }
