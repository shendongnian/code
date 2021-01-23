        using (var ax = new Axapta())
        {
            ax.Logon(null, null, null, null);
            int tableId = ax.GetTableId("TaxTable");
            var query = ax.CreateAxaptaObject("Query");
            var qbd = (AxaptaObject)query.Call("addDataSource", tableId);
            var qr = ax.CreateAxaptaObject("QueryRun", query); 
            while ((bool)qr.Call("next"))
            {
                var record = (AxaptaRecord)qr.Call("Get", tableId); 
                Console.WriteLine("TaxCode: {0}", record.get_Field("TaxCode"));
                Console.WriteLine("TaxName: {0}", record.get_Field("TaxName"));
            }
            ax.Logoff();
        } 
