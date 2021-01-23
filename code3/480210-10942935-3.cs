	private class WhereSelectEnumerableIterator<TSource, TResult> : Enumerable.Iterator<TResult>
	{
		private IEnumerator<TSource> enumerator;
		private Func<TSource, bool> predicate;
		private Func<TSource, TResult> selector;
		private IEnumerable<TSource> source;
	
		public WhereSelectEnumerableIterator(IEnumerable<TSource> source, Func<TSource, bool> predicate, Func<TSource, TResult> selector)
		{
			this.source = source;
			this.predicate = predicate;
			this.selector = selector;
		}
	
		public override Enumerable.Iterator<TResult> Clone()
		{
			return new Enumerable.WhereSelectEnumerableIterator<TSource, TResult>(this.source, this.predicate, this.selector);
		}
	
		public override void Dispose()
		{
			if (this.enumerator != null)
			{
				this.enumerator.Dispose();
			}
			this.enumerator = null;
			base.Dispose();
		}
	
		public override bool MoveNext()
		{
			switch (base.state)
			{
				case 1:
					this.enumerator = this.source.GetEnumerator();
					base.state = 2;
					break;
	
				case 2:
					break;
	
				default:
					goto Label_007C;
			}
			while (this.enumerator.MoveNext())
			{
				TSource current = this.enumerator.Current;
				if ((this.predicate == null) || this.predicate(current))
				{
					base.current = this.selector(current);
					return true;
				}
			}
			this.Dispose();
		Label_007C:
			return false;
		}
	
		public override IEnumerable<TResult2> Select<TResult2>(Func<TResult, TResult2> selector)
		{
			return new Enumerable.WhereSelectEnumerableIterator<TSource, TResult2>(this.source, this.predicate, Enumerable.CombineSelectors<TSource, TResult, TResult2>(this.selector, selector));
		}
	
		public override IEnumerable<TResult> Where(Func<TResult, bool> predicate)
		{
			return (IEnumerable<TResult>) new Enumerable.WhereEnumerableIterator<TResult>(this, predicate);
		}
	}
