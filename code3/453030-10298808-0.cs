    DAC DC = new DAC();
    DC.StoredProcedure = "nProc_InsertOrder";
    DC.Params.Add("@OrderId", SqlDbType.VarChar, "Order1" );
    DC.Params.Add("@CustomerName", SqlDbType.VarChar, "test");
    DAC.Commands.Add(DC);
     
    DC = new DAC();
    DC.StoredProcedure = "nProc_InsertOrderLineItems";
    DC.Params.Add("@OrderId", SqlDbType.VarChar, "Order1" );
    DC.Params.Add("@OrderLineId", SqlDbType.VarChar, "A1");
    DAC.Commands.Add(DC);
     
    DC = new DAC();
    DC.StoredProcedure = "nProc_InsertOrderLineItems";
    DC.Params.Add("@OrderId", SqlDbType.VarChar, "Order1" );
    DC.Params.Add("@OrderLineId", SqlDbType.VarChar, "A2");
    DAC.Commands.Add(DC);
     
    DC = new DAC();
    DC.StoredProcedure = "nProc_CreateBill";
    DC.Params.Add("@BillDate", SqlDbType.DateTime, DateTime.Now);
    DC.Params.Add("@BillId", SqlDbType.VarChar, "Bill1");
    DAC.Commands.Add(DC);
    DAC.ExecuteBatch();
 
