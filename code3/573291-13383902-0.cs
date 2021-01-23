            if (!Directory.Exists(Application.StartupPath + "\\data"))
            {
                Directory.CreateDirectory(Application.StartupPath + "\\data");
            }
            SQLiteConnection conGlobal;
            if (!File.Exists(dbGlobal))
            {
                conGlobal = new SQLiteConnection("Data Source=" + dbGlobal + ";New=True;Compress=True;PRAGMA synchronous = 1;PRAGMA journal_mode=WAL");
                conGlobal.SetExtendedResultCodes(true);
                firstRun = true;
            }
            else
            {
                conGlobal = new SQLiteConnection("Data Source=" + dbGlobal + ";Compress=True;PRAGMA synchronous = 1;PRAGMA journal_mode=WAL");
                conGlobal.SetExtendedResultCodes(true);
            }
            try
            {
                conGlobal.Open();
            }
            catch (Exception)
            {
                //do stuff
            }
