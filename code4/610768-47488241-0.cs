    public delegate void ToEachTransformAction<T>(ref T Telement);
	public void ToEach<T>(Generic.ICollection<T> CollectionToAlter, ToEachTransformAction<T> Transform)
	{
		for (var n = 0; n < CollectionToAlter.Count; n++)
		{
			Transform.Invoke(CollectionToAlter(n));
		}
	}
