        class FunkyTextBox : TextBox
        {
            int counter = 0;
            int MAX_CHANGES = 3;
            public event EventHandler FunkyTextChanged;
            public FunkyTextBox()
            {
            }
            protected override void OnTextChanged(EventArgs e)
            {
                base.OnTextChanged(e);
                if (++counter < MAX_CHANGES)
                    return;
                counter = 0;
                if (FunkyTextChanged != null)
                    FunkyTextChanged(this, null);
            }
        }
