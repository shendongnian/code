            [ClassInitialize]
            {
                if (DispatcherHelper.UIDispatcher == null)
                {
                    DispatcherHelper.Initialize();
                }
            }
