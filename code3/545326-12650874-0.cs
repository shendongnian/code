            button1.Click += (s, e) =>
            {
                button1.Enabled = false;
                var counter = 0;
                var timer = new Timer()
                {
                    Interval = 500,
                    Enabled = false
                };
                EventHandler handler = null;
                handler = (s2, e2) =>
                {
                    if (++counter >= 5)
                    {
                        timer.Stop();
                        timer.Tick -= handler;
                        timer.Dispose();
                        textBoxInvFooter.ForeColor = SystemColors.WindowText;
                        button1.Enabled = true;
                    }
                    else
                    {
                        textBoxInvFooter.ForeColor =
                            textBoxInvFooter.ForeColor == SystemColors.GrayText
                                ? SystemColors.Highlight 
                                : SystemColors.GrayText;
                    }
                };
                timer.Tick += handler;
                timer.Start();
            };
