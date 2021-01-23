        public OrderTransaction get_OrderTransaction_Master_ByOrderID(long OrderId)
        {
            string MethodName = "public OrderTransaction get_OrderTransaction_Master_ByOrderID(long OrderId)";
            OrderTransaction Result = null;
            try{
                StringBuilder sbSQL = new StringBuilder();
                sbSQL.AppendLine(" SELECT");
                sbSQL.AppendLine("    *");
                sbSQL.AppendLine(" FROM");
                sbSQL.AppendLine("    dbo.OrderTransaction_Master");
                sbSQL.AppendLine(" WHERE");
                sbSQL.AppendLine("    OrderID = " + OrderID);
                DataTable Dt = DBGetDataTable(sbSQL.ToString())
                OrderTransaction OrderTransaction = new OrderTransaction(Dt);
                Result = OrderTransaction;
            }
            catch(Exception ex)
            {
                //Common.Exception(ClassName,MethodName,ex);
            }
            return Result;
        }
