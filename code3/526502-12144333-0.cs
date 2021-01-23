            // For Me Server is ".\SQLExpress" You may have changed
            Server myServer = new Server(@".\SQLExpress");
            Scripter scripter = new Scripter(myServer);
            
            //Databas1 is your database Name Thats Changable
            Database myAdventureWorks = myServer.Databases["Database1"];
            /* With ScriptingOptions you can specify different scripting  
            * options, for example to include IF NOT EXISTS, DROP  
            * statements, output location etc*/
            ScriptingOptions scriptOptions = new ScriptingOptions();
            scriptOptions.ScriptDrops = true;
            scriptOptions.IncludeIfNotExists = true;
            string scrs = "";
            string tbScr = "";
            foreach (Table myTable in myAdventureWorks.Tables)
            {
                /* Generating IF EXISTS and DROP command for tables */
                StringCollection tableScripts = myTable.Script(scriptOptions);
                foreach (string script in tableScripts)
                    scrs += script;
                /* Generating CREATE TABLE command */
                tableScripts = myTable.Script();
                foreach (string script in tableScripts)
                    tbScr += script;
            }
            // For WinForms
            MessageBox.Show(scrs + "\n\n" + tbScr);
            //For Console
            //Console.WriteLine(scrs + "\n\n" + tbScr);
