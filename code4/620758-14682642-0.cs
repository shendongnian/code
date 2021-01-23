	private void CalculateStatistics(IEnumerable<Double> valuesToAggregate)
	{
		// We need to iterate multiple times over the values, so it makes
		// sense to create a list to improve performance.
		var aggregateMe = valuesToAggregate.ToList();
		if (aggregateMe.Count > 0)
		{
			// To calculate the median, the simplest approach
			// is to sort the list.
			aggregateMe.Sort();
			// Cause we already sorted the list,
			// the min value must be available within the first element.
			Min = aggregateMe[0];
			// the max value must be available within the last element.
			Max = aggregateMe[aggregateMe.Count - 1];
			// The average has really to be calculated, by another iteration run.
			Mean = aggregateMe.Average();
			// Taking the median from a sorted list is easy.
			var midpoint = (aggregateMe.Count - 1) / 2;
			Median = aggregateMe[midpoint];
			// If the list contains a even number of element,
			// the median is the average of the two elements around the midpoint.
			if (aggregateMe.Count % 2 == 0)
				Median = (Median + aggregateMe[midpoint + 1]) / 2;
		}
		else
		{
			// There is no value available to calculate some statistic.
			Min = Double.NaN;
			Max = Double.NaN;
			Mean = Double.NaN;
			Median = Double.NaN;
		}
	}
