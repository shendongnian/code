     public class RecursiveDeleteCustomAction
        {
           
            [CustomAction]
            public static ActionResult RecursiveDeleteCosting(Session session)
            {
                // SOMECOMPONENTID is the Id attribute of a component in your install that you want to use to trigger this happening
                const string ComponentID = "SOMECOMPONENTID";
                // SOMEDIRECTORYID would likely be INSTALLDIR or INSTALLLOCATION depending on your MSI
                const string DirectoryID = "SOMEDIRECTORYID";
    
                var result = ActionResult.Success;
                int index = 1;
    
                try
                {
                    string installLocation = session[DirectoryID];
                    session.Log("Directory to clean is {0}", installLocation);
    
                    // Author rows for root directory
                    // * means all files
                    // null means the directory itself
                    var fields = new object[] { "CLEANROOTFILES", ComponentID, "*", DirectoryID, 3 };
                    InsertRecord(session, "RemoveFile", fields);
                    fields = new object[] { "CLEANROOTDIRECTORY", ComponentID, "", DirectoryID, 3 };
                    InsertRecord(session, "RemoveFile", fields);
    
                    if( Directory.Exists(installLocation))
                    {
                        foreach (string directory in Directory.GetDirectories(installLocation, "*", SearchOption.AllDirectories))
    	                {
                            session.Log("Processing Subdirectory {0}", directory);
                            string key = string.Format("CLEANSUBFILES{0}", index);
                            string key2 = string.Format("CLEANSUBDIRECTORY{0}", index);
                            session[key] = directory;
    
                            fields = new object[] { key, ComponentID, "*", key, 3 };
                            InsertRecord(session, "RemoveFile", fields);
    
                            fields = new object[] { key2, ComponentID, "", key, 3 };
                            InsertRecord(session, "RemoveFile", fields);
                                
                            index++;	 
    	                }
                    }
                }
                catch (Exception ex)
                {
                    session.Log(ex.Message);
                    result = ActionResult.Failure;
                }
    
                return result;
            }
            private static void InsertRecord(Session session, string tableName, Object[] objects)
            {
                Database db = session.Database; 
                string sqlInsertSring = db.Tables[tableName].SqlInsertString + " TEMPORARY";
                session.Log("SqlInsertString is {0}", sqlInsertSring);
                View view = db.OpenView(sqlInsertSring); 
                view.Execute(new Record(objects)); 
                view.Close(); 
            }
        }
