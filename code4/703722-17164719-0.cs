        private void appShortcutToStartup()
        {
            string linkName ="MytestLink";
            string startDir = Environment.GetFolderPath(Environment.SpecialFolder.Startup);
            if (!System.IO.File.Exists(startDir + "\\" + linkName + ".url"))
            {
                using (StreamWriter writer = new StreamWriter(startDir + "\\" + linkName + ".url"))
                {
                    string app = System.Reflection.Assembly.GetExecutingAssembly().Location;
                    writer.WriteLine("[InternetShortcut]");
                    writer.WriteLine("URL=file:///" + app);
                    writer.WriteLine("IconIndex=0");
                    string icon = Application.StartupPath + "\\backup (3).ico";
                    writer.WriteLine("IconFile=" + icon);
                    writer.Flush();
                }
            }
        }
