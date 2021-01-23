        bool zero = Convert.ToBoolean(this.Parameters[0].Value);
        bool one = Convert.ToBoolean(this.Parameters[1].Value);
        if (zero || one) // true if 'zero' or 'one' is true
        {
            ((SplineSeriesView)xrChart1.Series[0].View).AxisY.Visible = true;
        }
        else // goes here if both 'zero' and 'one' is false
        {
            ((SplineSeriesView)xrChart1.Series[0].View).AxisY.Visible = false;
        }
