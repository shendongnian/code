            for (int i = panel1.Controls.Count - 1; i >= 0; i--)
            {
                Control c = panel1.Controls[i];
                lastValue = (int)Char.GetNumericValue(c.Name, c.Name.Length - 1);
                if (lastValue > 0 && lastValue < count)
                {
                    c.Dispose();
                }
            }
