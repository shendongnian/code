    public class Command
    {
        public string sql { get; set; }
        public CommandType cmdType { get; set; }
        public Dictionary<string, object> parameter { get; set; } = null;
    }
        private Command insertInvoice(Invoice invoice)
        {
            try
            {
                Dictionary<string, object> parameterLocal = new Dictionary<string, object>();
                parameterLocal.Add("p_customerId", invoice.customerId);
                parameterLocal.Add("p_invoiceNo", invoice.invoiceNo);
                parameterLocal.Add("p_invoiceDate", invoice.invoiceDate);
                parameterLocal.Add("p_invoiceAmount", invoice.invoiceAmount);                
                parameterLocal.Add("p_withInvoice", invoice.withInvoice);
                return (new Command { sql = "sp_insertInvoice", cmdType = CommandType.StoredProcedure, parameter = parameterLocal });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private Command insertInvoiceModel(InvoiceModel invoiceModel)
        {
            try
            {
                Dictionary<string, object> parameterLocal = new Dictionary<string, object>();
                parameterLocal.Add("p_invoiceNo", invoiceModel.invoiceNo);
                parameterLocal.Add("p_model", invoiceModel.model);
                parameterLocal.Add("p_quantity", invoiceModel.quantity);
                parameterLocal.Add("p_unitPrice", invoiceModel.unitPrice);
                return (new Command { sql = "sp_insertInvoiceModel", cmdType = CommandType.StoredProcedure, parameter = parameterLocal });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
