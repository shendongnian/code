    AtmEntity
    {
      long Id {get;set;}
      ... some properties ...
      HashSet<Transaction> AtmTransactions {get;set;}
    }
    
