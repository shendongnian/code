     if (txtOutput.Text.Length > 0)
            {
                MatchCollection mc = Regex.Matches(txtOutput.Text, @"(\+|-)?\d+");
                if (mc.Count > 0)
                {
                    long value = long.Parse(mc[mc.Count - 1].Value);
                    if (value < 1000)
                    {
                        textBox2.Text = value.ToString();
                    }
                    else
                    {
                        value = value - 1000;
                        textBox3.Text = value.ToString();
                    }
                }
            }
