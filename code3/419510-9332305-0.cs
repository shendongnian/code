            var DateMarket = from p in Orders_From_CRD.AsEnumerable()
                         where p.Field<Double?>("Fill_ID") != null
                         select OrderTable.Rows.Add(p.Field<DateTime>("trade_date"), p.Field<string>("ticker"),
                         p.Field<Double?>("EXEC_QTY"), p.Field<Double?>("EXEC_PRICE"));
        TradeTable = DateMarket.CopyToDataTable();
