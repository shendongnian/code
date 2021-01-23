    class Collection { public string CurrencyID; public Int32 Value; }
    class Invoice { public string CurrencyID; public Int32 Value; }
    ...
	List<Collection> collections = new List<Collection> {
		new Collection() {CurrencyID="USD", Value=10},
		new Collection() {CurrencyID="EUR", Value=20},
		new Collection() {CurrencyID="JPN", Value=50}
	};
	
	List<Invoice> invoices = new List<Invoice> {
		new Invoice() {CurrencyID="USD", Value=50},
		new Invoice() {CurrencyID="EUR", Value=30},
		new Invoice() {CurrencyID="CAN", Value=40}
	};
