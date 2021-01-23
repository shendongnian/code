    private void CreateInvoice(Invoice _invoice)
    {
        IOrganizationService _service = GetCRMService();
        // Getting all invoices with given number 
        var filter = new FilterExpression();
        filter.AddCondition(e_Invoice.InvoiceNumber, ConditionOperator.Equal, _invoice.Id.ToString());
        var query = new QueryExpression("invoice")
        {
            ColumnSet = new ColumnSet(true),
            Criteria = filter,
            Distinct = true
        };
        
        // Executing query
        var invoices = (EntityCollection)_service.RetrieveMultiple(query);
        if (invoices.Entities.Count == 0)
        {
            // Creating new invoice
            Entity entity = new Entity("invoice");
            entity[e_Invoice.InvoiceNumber] =  _invoice.Id.ToString();
            entity[e_Invoice.CustomerId] = new EntityReference("account", new Guid("6209A6AD-43B6-E211-A99D-005056A51C55"));
            _service.Create(entity);
        }
    }
