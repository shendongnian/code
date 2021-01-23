        private void SetupButtonClickListenerForPanel1()
        {
            panel1.Click += ListenForAllButtonClickOnPanel1;
            foreach (Control control in panel1.Controls)
            {
                var tb = control as Button;
                if (tb != null)
                {
                    tb.Click += ListenForAllButtonClickOnPanel1;
                }
            }
            
        }
        private void ListenForAllButtonClickOnPanel1(object sender, EventArgs eventArgs)
        {
            //
            Button tb = (Button) sender; // casting will fail if click is on Panel1 itself!
            MessageBox.Show(tb.Name);
        }
