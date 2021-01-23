        private static readonly double SCALE_FACTOR = 10;
        private static readonly double MIN_CHART_VALUE
            = Convert.ToDouble(Decimal.MinValue) / SCALE_FACTOR;
        private static readonly double MAX_CHART_VALUE
            = Convert.ToDouble(Decimal.MaxValue) / SCALE_FACTOR;
        
        private void SafeChartDouble(Series cs, DateTime ts, double dv)
        {
            // microsoft chart component breaks on very large/small values
            double chartv;
            if (dv < MIN_CHART_VALUE)
            {
                chartv = MIN_CHART_VALUE;
            }
            else if (dv > MAX_CHART_VALUE)
            {
                chartv = MAX_CHART_VALUE;
            }
            else
            {
                chartv = dv;
            }
            cs.Points.AddXY(ts, chartv);
        }
