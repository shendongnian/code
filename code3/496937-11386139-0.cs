     private string _textBlockText;
            public string textBlockText
            {
                get { return _textBlockText; }
                set
                {
                    if (txtSample.Text != value)
                    {
                        if (Storyboard1.GetCurrentState() != ClockState.Active)
                            Storyboard1.Begin();
                        txtSample.Text = value;
                    }
                }
            }
