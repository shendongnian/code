	public void Update(int destinationIndex, int[][] arrays, int[] indices) {
		var product=1;
		for(var i=indices.Length; i-->0; )
			if(destinationIndex!=i)
				product*=arrays[i][indices[i]];
		arrays[destinationIndex][indices[destinationIndex]]+=product;
	}
	public void PerformUpdate(
		int destinationIndex, int[] counts, int[][] arrays, Action<int, int>[] actions,
		List<int> indices=null, int level=0
		) {
		if(level==counts.Length)
			Update(destinationIndex, arrays, (indices??new List<int>()).ToArray());
		else
			for(int count=counts[level], i=0; i<count; i++) {
				if(null!=actions&&level<actions.Length)
					actions[level](i, count); // do something according to nesting level
				(indices=indices??new List<int>()).Add(i);
				PerformUpdate(destinationIndex, counts, arrays, actions, indices, 1+level);
				indices.RemoveAt(indices.Count-1);
			}
	}
