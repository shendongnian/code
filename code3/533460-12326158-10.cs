    var transaction = new Transaction();
    
    // This line works fine:
    var transactionAmount = transaction.Amount;
    
    
    
    var invoice = new Invoice();
    
    // This line works fine:
    var invoiceSubtotal = invoice.SubTotal;
    
    // This line won't compile.
    // Error: TransactionBase.Amount is inaccessible due to its protection level.
    var invoiceAmount = invoice.Amount;
