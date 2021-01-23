    private static List<Tuple<char,Node>> VisitOrder = new List<Tuple<char,Node>>();
    
    public void Visit()
    {
        VisitOrder.Add(Tuple.Create('L', this));
        // whatever visit logic you use here
        VisitOrder.Add(Tuple.Create('R', this));
    }
