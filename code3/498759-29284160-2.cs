	public static List<IEnumerable<T>> Batch<T>(this IEnumerable<T> items, int qtyPerBatch)	
	{		
		decimal iterations = items.Length / qtyPerBatch;		
		var roundedIterations = (int)Math.Ceiling(iterations);
		var batchItems = new List<IEnumerable<T>>();
		for (int i = 0; i < roundedIterations; i++)
		{		
			batchItems.Add(items.Skip(i * qtyPerBatch).Take(qtyPerBatch).ToArray());		
		}
		return batchItems;		
	}
