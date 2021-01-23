    public void LambdaConversionBasicWithEmissor()
        {
            var cust= new Customer();
            var items = new List<string>() { "PETR", "VALE" };
            var type = cust.GetType();
            // Here you have your results from the database
            var result = GetItemsFromContainsClause(type, items);
        }
