	public static List<T[]> Batch<T>(this T[] items, int qtyPerBatch)	
	{		
		decimal iterations = items.Length / qtyPerBatch;		
		var roundedIterations = (int)Math.Ceiling(iterations);
		var batchItems = new List<T[]>();
		for (int i = 0; i < roundedIterations; i++)
		{		
			batchItems.Add(items.Skip(i * qtyPerBatch).Take(qtyPerBatch).ToArray());		
		}
		return batchItems;		
	}
