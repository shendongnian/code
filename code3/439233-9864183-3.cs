        class MyClass
        {
            public EventHandler CheckbookRangeMissing
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
