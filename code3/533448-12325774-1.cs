    public class Invoice
    {
			private readonly Transaction _transaction; 
			public Invoice():this(new Transaction())
			{
			}
			public Invoice(Transaction transaction)
			{
				_transaction = transaction;
			}
		
			// This property should hide the generic property "Amount" on Transaction
			public double? SubTotal
			{
				get
				{
					return _transaction.Amount;
				}
				set
				{
					_transaction.Amount = value ?? 0.0f;
				}
			}
	
			public double RemainingBalance { get; set; }
		}
