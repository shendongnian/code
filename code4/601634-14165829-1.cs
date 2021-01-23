	for (int i = 0; i <= max; i += block)
	{
		tasks.Add(Task.Factory.StartNew(() => Count(ref counter, block)));
		if (i + block >= max) { block = max - i; }
	}
