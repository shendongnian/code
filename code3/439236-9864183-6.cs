        class MyClass
        {
            public event EventHandler<RangeMissingEventArgs> CheckbookRangeMissing =
                delegate { };
            public MyClass()
            {
                // initialize checkbook
                checkbook.RangeMissing += OnCheckbookRangeMissing;
            }
            private void OnCheckbookRangeMissing(object sender, EventArgs e)
            {
                CheckbookRangeMissing(this, e)
            }
        }
