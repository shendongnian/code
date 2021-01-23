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
     List<Command> commandList = new List<Command>();
     cmd = insertInvoice(invoicesave);
     commandList.Add(cmd);
     cmd = insertInvoiceModel(invoiceModelSave);
     commandList.Add(cmd);
            try
            {
                erplibmain.erpDac.runOleDbTransaction(commandList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        public void runOleDbTransaction(List<Command> commandList)
        {
            OleDbConnection erpConnection = new OleDbConnection(ErpDalMain.connectionstring);
            erpConnection.Open();
            OleDbCommand erpCommand = erpConnection.CreateCommand();
            OleDbTransaction erpTrans;
            // Start a local transaction
            erpTrans = erpConnection.BeginTransaction();
            // Assign transaction object for a pending local transaction
            erpCommand.Connection = erpConnection;
            erpCommand.Transaction = erpTrans;
            try
            {
                foreach (Command cmd in commandList)
                {
                    erpCommand.CommandText = cmd.sql;
                    erpCommand.CommandType = cmd.cmdType;
                    foreach (KeyValuePair<string, object> entry in cmd.parameter)
                    {
                        erpCommand.Parameters.AddWithValue(entry.Key, entry.Value);
                    }
                    erpCommand.ExecuteNonQuery();
                    erpCommand.Parameters.Clear();
                }
                erpTrans.Commit();
            }
            catch (Exception e)
            {
                try
                {
                    erpTrans.Rollback();
                }
                catch (OleDbException ex)
                {
                    if (erpTrans.Connection != null)
                    {
                        throw ex;
                    }
                }
                throw e;
            }
            finally
            {
                erpConnection.Close();
            }
        }
