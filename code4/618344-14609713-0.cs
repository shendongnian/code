        private void SetupButtonClickListenerForPanel1()
        {
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
            Button tb = (Button) sender;
            MessageBox.Show(tb.Name);
        }
