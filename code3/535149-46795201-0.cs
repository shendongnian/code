        void bsInvoiceDetails_AddingNew(object sender, AddingNewEventArgs e)
        {
            try
            {
                InvoiceDetail id = new InvoiceDetail();
                id.InvoiceID = invoice.InvoiceID;   // Make sure we are hooked to this invoice.
                id.DetailDate = DateTime.Today;
                id.DetailQuantity = 0;
                id.DetailRate = 0;
                id.DetailTotal = 0;
                id.DetailDescription = "* New Detail Description *";
                e.NewObject = id;
            }
            catch (Exception ex)
            {
                ErrorManager em = new ErrorManager(ex, "InvoiceEditForm.cs", "bsInvoiceDetails_ListChanged", "Adding a new detail item", "sql");
            }
        }
