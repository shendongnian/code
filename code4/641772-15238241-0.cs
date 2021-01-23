    public new IEnumerator<ImageElement> GetEnumerator()
    {
    	var iter = base.GetEnumerator();
    	while (iter.MoveNext()) yield return (ImageElement)iter.Current;
    }
