	// convert tree into collection of value sets
	public IEnumerable<List<string>> ExplodeValueSets(T tree, int cIndex = 0) {
		// recursive portion as long as there are more columns to process
		if (cIndex < tree.column.Length) {
			// recursive generate list for rest of columns
			var subResult = ExplodeValueSets(tree, cIndex + 1);
			// combine values in this column with recursively-generated
			// sets from rest of columns to build up larger sets
			foreach (var result in subResult)
				foreach (var value in tree.column[cIndex].value)
					yield return new List<string> { value.fieldVal }.Concat(result).ToList();
		} else {
			// base condition - all columns are processed, so return empty list
			yield return new List<string>();
		}
	}
