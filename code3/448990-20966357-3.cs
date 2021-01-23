    public static int FindNearest(int targetNumber, IEnumerable<int> collection) {
		var results = collection.ToArray();
		int nearestValue;
		if (results.Any(ab => ab == targetNumber))
			nearestValue = results.FirstOrDefault(i => i == targetNumber);
		else{
			int greaterThanTarget = 0;
			int lessThanTarget = 0;
			if (results.Any(ab => ab > targetNumber)) {
				greaterThanTarget = results.Where(i => i > targetNumber).Min();
			}
			if (results.Any(ab => ab < targetNumber)) {
				lessThanTarget = results.Where(i => i < targetNumber).Max();
			}
			if (lessThanTarget == 0) {
				nearestValue = greaterThanTarget;
			}
			else if (greaterThanTarget == 0) {
				nearestValue = lessThanTarget;
			}
			else if (targetNumber - lessThanTarget < greaterThanTarget - targetNumber) {
				nearestValue = lessThanTarget;
			}
			else {
				nearestValue = greaterThanTarget;
			}
		}
		return nearestValue;
	}
