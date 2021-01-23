    /// <summary>
    /// Log the invoice status change
    /// </summary>
    /// <param name="value">The value that the invoice status is changing to</param>
    partial void OnInvoiceStatusValueChanging(string value)
    {
        var newStatus = ConvertInvoiceStatus(value);
        if (this.EntityKey != null && InvoiceStatus != newStatus)
        {
            AddNewNote(string.Format("Invoice status changing from [{0}] to [{1}]", InvoiceStatus.GetDescription(), newStatus.GetDescription()));
        }
    }
    /// <summary>
    /// Log the invoice status change
    /// </summary>
    partial void OnInvoiceStatusValueChanged()
    {
        if (this.EntityKey != null)
            AddNewNote(string.Format("Invoice status changed to [{0}]", InvoiceStatus.GetDescription()));
    }
