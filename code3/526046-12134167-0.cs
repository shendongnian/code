    public static string dumpTables(SMO.TableCollection tables)
            {
                SMO.ScriptingOptions scriptingOptions = new SMO.ScriptingOptions();
                scriptingOptions.IncludeIfNotExists = true;
                scriptingOptions.DriAll = true;
                scriptingOptions.ExtendedProperties = true;
                SMO.Scripter scripter = new SMO.Scripter();
                scripter.Options = scriptingOptions;
    
                return scripter.Script(tables);
            }
