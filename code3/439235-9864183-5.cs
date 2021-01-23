        class MyClass
        {
            public event EventHandler<RangeMissingEventArgs>
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
