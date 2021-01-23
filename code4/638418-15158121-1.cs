        class FunkyTextBox : TextBox
        {
            int counter = 0;
            int MAX_CHANGES = 3;
            public FunkyTextBox()
            {
            }
            protected override void OnTextChanged(EventArgs e)
            {
                if (++counter < MAX_CHANGES)
                    return;
                counter = 0;
                base.OnTextChanged(e);
            }
        }
