    public void UpdateWorkOrder(int workOrderID, int paymentTermTypeID, string acceptedBy, string lastIssuedBy)
    {
        using (var data = new DataAccess(this.ConnectionString))
        {
            data.ProcedureName = "UpdateWorkOrderDetails";
            data.AddParm("@WorkOrderID", SqlDbType.Int, workOrderID);
            data.AddParm("@PaymentTermTypeID", SqlDbType.Int, paymentTermTypeID);
            data.AddParm("@AcceptedBy", SqlDbType.VarChar, acceptedBy);
            data.AddParm("@LastIssuedBy", SqlDbType.VarChar, lastIssuedBy);
            data.ExecNonQuery();
        }
    }
    public DataTable GetWorkOrder(int workOrderID)
    {
        using (var data = new DataAccess(this.ConnectionString))
        {
            data.ProcedureName = "GetWorkOrder";
            data.AddParm("@WorkOrderID", SqlDbType.Int, workOrderID);
            return data.ExecReturnDataTable();
        }
    }
