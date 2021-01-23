           DataSet ds = new DataSet();
            DataTable dtemploye = new DataTable();
            DataTable dtpayment = new DataTable();
            ds.Tables.AddRange(new DataTable[] { dtemploye, dtpayment });
            DataColumn dcIdemploye = dtemploye.Columns["ID_EMPLOYEE"];
            DataColumn dcIdemployeprice = dtpayment.Columns["ID_EMPLOYEE"];
            DataRelation drrelation = new DataRelation("relemploy_payment", dcIdemploye, dcIdemployeprice);
            ds.Relations.Add(drrelation);
