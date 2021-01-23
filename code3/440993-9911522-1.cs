     DBEngine dbEng = new DBEngine();
     Workspace ws = dbEng.CreateWorkspace("", "admin", "", 
        WorkspaceTypeEnum.dbUseJet);
     Database db = ws.OpenDatabase("z:\\docs\\test.accdb", false, false, "");
     
     foreach (TableDef tdf in db.TableDefs)
     {
         string tablename=tdf.Name;
         if (tablename.Substring(0,4) != "MSys")
         {
             string sSQL = "SELECT * INTO [Text;FMT=Delimited;HDR=Yes;DATABASE=Z:\\Docs].[out_" 
                + tablename + ".csv] FROM " + tablename;
             db.Execute(sSQL);
         }
     }
    
