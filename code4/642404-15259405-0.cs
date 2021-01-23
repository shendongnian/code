	class MyEntity{
		public virtual decimal Amount { get; set; }
		public virtual Parent Parent { get; set; }
		public virtual decimal DivideOfThisAmountOnAll
		{
			get
			{
				var sum = Parent.MyEntities.Sum(e=> e.Amount);
				return this.Amount / sum;
			}
		}
	}
