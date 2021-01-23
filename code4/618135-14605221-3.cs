    static public void Main()
    {
        // Example of dataset
        List<TransactionInfo> transactionInfos = new List<TransactionInfo>()
        {
            new TransactionInfo(1, "A", "B"),
            new TransactionInfo(2, "A", "C"),
            new TransactionInfo(3, "A", "D"),
            new TransactionInfo(4, "G", "H"),
            new TransactionInfo(5, "C", "M"),
            new TransactionInfo(6, "D", "E"),
            new TransactionInfo(7, "A", "F"),
            new TransactionInfo(8, "H", "L"),
            new TransactionInfo(9, "L", "R"),
            new TransactionInfo(10, "Y", "Z"),
        };
    
        // Creates the graph and add the arcs
        UndirectedGraph<string> graph = new UndirectedGraph<string>();
        foreach (TransactionInfo transactionInfo in transactionInfos)
            graph.AddArc(transactionInfo.SellerName, transactionInfo.BuyerName);
    
        var result = (from clusterByNode in graph.GetConnectedComponents()  // Gets the connected components
                      select (from transactionInfo in transactionInfos  // Gets the transaction infos
                              join node in clusterByNode on transactionInfo.BuyerName equals node  // Joins the transactionInfo with the node in the connected component
                              select transactionInfo).ToList()).ToList();
    }
