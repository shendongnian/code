            // Create a thread specific NumericUpDown control used for the painting of the non-edited cells
            if (paintingNumericUpDown == null || paintingNumericUpDown.IsDisposed)
            {
                paintingNumericUpDown = new NumericUpDown();
                // Some properties only need to be set once for the lifetime of the control:
                paintingNumericUpDown.BorderStyle = BorderStyle.None;
                paintingNumericUpDown.Maximum = Decimal.MaxValue / 10;
                paintingNumericUpDown.Minimum = Decimal.MinValue / 10;
            }
