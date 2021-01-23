     using Microsoft.Office.Interop.Access.Dao;
            DBEngine dbEng = new DBEngine();
            Workspace ws = dbEng.CreateWorkspace("", "admin", "",
                WorkspaceTypeEnum.dbUseJet);
            Database db = ws.OpenDatabase(@"z:\docs\test.accdb", false, false, "");
            TableDef tdf = db.TableDefs["Table1"];
            Field fld = tdf.Fields["Field1"];
            Property prp = fld.CreateProperty("Caption", 10, "My caption");
            fld.Properties.Append(prp);
