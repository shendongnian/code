    private void ICallUtiltyFunction()
    {
        QueryContext context = new QueryContext(); // I don't know if this is really how to instantiate this object
        // Add these here, because this function knows what it needs and
        // it already created the queryContext object
        context.OrderByColumns.Add("param_1");
        context.OrderByColumns.Add("param_2"); 
        // I also know my limit and start here
        context.Offset = 30;
        context.Limit = 30;
        int totalRecords = 0; // You really don't need this, it's wasteful
        DataTable results = Utilities.GetRecords(dataAccess, context, totalRecords);
        
        // Use the results now
    }
