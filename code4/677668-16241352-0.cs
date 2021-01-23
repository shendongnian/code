     internal long value;
            private void SetText(string text)
            {
                if (this.txtOutput.InvokeRequired)
                {
                    SetTextCallback d = new SetTextCallback(SetText);
                    this.BeginInvoke(d, new object[] { text });
                }
                else
                {
                    txtOutput.AppendText(text);
                }
                // capture messages from serial port
                if (txtOutput.Text.Length > 0)
                {
                    MatchCollection mc = Regex.Matches(txtOutput.Text, @"(\+|-)?\d+");
                    if (mc.Count > 0)
                    {
                        value = long.Parse(mc[mc.Count - 1].Value);
                        if (value > 1 && value < 1000)
                        {
                            textBox2.Text = value.ToString();
                        }
                        else if (value < 2000 && value > 1000)
                        {
                            value = value - 1000;
                            textBox3.Text = value.ToString();
                        }
                    }
                }
            }
