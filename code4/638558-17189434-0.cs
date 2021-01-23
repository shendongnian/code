    PropertyBag connectionAttributes = new PropertyBag();
    connectionAttributes.Add("Auto Translate", "-1");
    connectionAttributes.Add("Connect Timeout", "15");
    connectionAttributes.Add("Data Source", Server);
    connectionAttributes.Add("General Timeout", "0");
    connectionAttributes.Add("Initial Catalog", Database);
    connectionAttributes.Add("Integrated Security", false);
    connectionAttributes.Add("Locale Identifier", "1040");
    connectionAttributes.Add("OLE DB Services", "-5");
    connectionAttributes.Add("Provider", "SQLOLEDB");
    connectionAttributes.Add("Tag with column collation when possible", "0");
    connectionAttributes.Add("Use DSN Default Properties", false);
    connectionAttributes.Add("Use Encryption for Data", "0");
    
    PropertyBag attributes = new PropertyBag();
    attributes.Add("Database DLL", "crdb_ado.dll");
    attributes.Add("QE_DatabaseName", Database);
    attributes.Add("QE_DatabaseType", "OLE DB (ADO)");
    attributes.Add("QE_LogonProperties", connectionAttributes);
    attributes.Add("QE_ServerDescription", Server);
    attributes.Add("QESQLDB", true);
    attributes.Add("SSO Enabled", false);
    
    CrystalDecisions.ReportAppServer.DataDefModel.ConnectionInfo ci = new CrystalDecisions.ReportAppServer.DataDefModel.ConnectionInfo();
    ci.Attributes = attributes;
    ci.Kind = CrConnectionInfoKindEnum.crConnectionInfoKindCRQE;
    ci.UserName = Username;
    ci.Password = Password;
    
    foreach (CrystalDecisions.ReportAppServer.DataDefModel.Table table in Report.ReportClientDocument.DatabaseController.Database.Tables)
    {
        CrystalDecisions.ReportAppServer.DataDefModel.Procedure newTable = new CrystalDecisions.ReportAppServer.DataDefModel.Procedure();
        
        newTable.ConnectionInfo = ci;
        newTable.Name = table.Name;
        newTable.Alias = table.Alias;
        newTable.QualifiedName = table.QualifiedName;
        Report.ReportClientDocument.DatabaseController.SetTableLocation(table, newTable);
    }
    
    foreach (ReportDocument subreport in Report.Subreports)
    {
        foreach (CrystalDecisions.ReportAppServer.DataDefModel.Table table in Report.ReportClientDocument.SubreportController.GetSubreportDatabase(subreport.Name).Tables)
        {
            CrystalDecisions.ReportAppServer.DataDefModel.Procedure newTable = new CrystalDecisions.ReportAppServer.DataDefModel.Procedure();
    
            newTable.ConnectionInfo = ci;
            newTable.Name = table.Name;
            newTable.Alias = table.Alias;
            newTable.QualifiedName = table.QualifiedName;
            Report.ReportClientDocument.SubreportController.SetTableLocation(subreport.Name, table, newTable);
        }
    }
