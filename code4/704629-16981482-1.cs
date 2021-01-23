    public static DataPoint Average(this IEnumerable<DataPoint> dataPoints)
    {
        var count = 0;
        var totals = dataPoints.Aggregate((lhs, rhs) =>
            {
                ++count;
                return new DataPoint
                    {
                        Plus100 = lhs.Plus100 + rhs.Plus100,
                        Plus50 = lhs.Plus50 + rhs.Plus50,
                        Plus10 = lhs.Plus10 + rhs.Plus10,
                        Plus5 = lhs.Plus5 + rhs.Plus5,
                        Plus1 = lhs.Plus1 + rhs.Plus1,
                        NULLA = lhs.NULLA + rhs.NULLA
                    };
            });
        return new DataPoint
            {
                Plus100 = totals.Plus100 / count,
                Plus50 = totals.Plus50 / count,
                Plus10 = totals.Plus10 / count,
                Plus5 = totals.Plus5 / count,
                Plus1 = totals.Plus1 / count,
                NULLA = totals.NULLA / count
            };
    }
