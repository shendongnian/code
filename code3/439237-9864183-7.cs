        class MyClass
        {
            public event EventHandler<RangeMissingEventArgs> CheckbookRangeMissing 
            {
                add
                {
                    checkbook.RangeMissing += value;
                }
                remove
                {
                    checkbook.RangeMissing -= value;
                }
            }
        }
