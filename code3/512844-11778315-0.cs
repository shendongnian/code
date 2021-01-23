	var validValues = values
		.Where(v => Math.Abs(v) < upperLimit) //filter out anything that will always fail
		.OrderBy(v => Math.Abs(v)); //sort by the absolute value (to maximise # of transactions)
	var additions              = validValues.Where(v => v >= 0);
	var subtractionsEnumerator = validValues.Where(v => v < 0).GetEnumerator();
	var currentTotal           = 0.0;
	//go through all of the additions
	foreach (var addition in additions)
	{
		if (currentTotal + addition > upperLimit) //would the next addition take us over the limit?
		{
			//keep processing negative values until the next one would take us past $0
			while (subtractionsEnumerator.MoveNext() && currentTotal + subtractionsEnumerator.Current > 0)
			{
				currentTotal += subtractionsEnumerator.Current;
			}
		}
		if (currentTotal + addition > upperLimit) //if we weren't able to reduce by enough
			throw new Exception("Can't process transactions");
		currentTotal += addition;
	}
	//do we have any left over negatives?  better process those as well
	while (subtractionsEnumerator.MoveNext())
	{
		if (currentTotal + subtractionsEnumerator.Current < 0)
			throw new Exception("Can't process transactions");
		currentTotal += subtractionsEnumerator.Current;
	}
