    public void Aggregate(int term, int reviewPeriod)
    {
        for (var year = 0; year < term; year++)
        {
            var currentRemainder = year % reviewPeriod;
            if (currentRemainder == 0)
            {
                this.PerformAggregation(reviewPeriod);
            }
            else
            {
                this.PerformAggregation(currentRemainder);
            }
        }
    }
