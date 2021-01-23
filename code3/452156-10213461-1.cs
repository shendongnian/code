            // Start a new instance of Access for Automation
            oAccess = new Access.Application();
            // Open a database
            oAccess.OpenCurrentDatabase(@"z:\docs\test.accdb");
            oAccess.DoCmd.TransferDatabase(
                Access.AcDataTransferType.acExport,
                "Microsoft Access",
                @"z:\docs\test.accdb",
                Access.AcObjectType.acTable, 
                "table1",
                "newtable",true,false);
