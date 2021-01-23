        private void SetupButtonClickListenerForPanel1()
        {
            panel1.Click += ListenForAllButtonClickOnPanel1;
            foreach (var tb in panel1.Controls.OfType<Button>())
            {
                tb.Click += ListenForAllButtonClickOnPanel1;
            }
        }
