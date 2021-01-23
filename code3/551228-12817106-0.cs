     static void Main(string[] args)
        {
            if (isFireFoxOpen())
            {
                Console.WriteLine("Firefox is open, close it");
            }
            else
            {
                string pathOfPrefsFile = GetPathOfPrefsFile();
                updateSettingsFile(pathOfPrefsFile);
                Console.WriteLine("Done");
            }
            Console.ReadLine();
        }
        private static void updateSettingsFile(string pathOfPrefsFile)
        {
            string[] contentsOfFile = File.ReadAllLines(pathOfPrefsFile);
            // We are looking for "user_pref("browser.download.useDownloadDir", true);"
            // This needs to be set to:
            // "user_pref("browser.download.useDownloadDir", false);"
            List<String> outputLines = new List<string>();
            foreach (string line in contentsOfFile)
            {
                if (line.StartsWith("user_pref(\"browser.download.useDownloadDir\""))
                {
                    Console.WriteLine("Found it already in file, replacing");
                }
                else
                {
                    outputLines.Add(line);
                }
            }
            // Finally add the value we want to the end
            outputLines.Add("user_pref(\"browser.download.useDownloadDir\", false);");
            // Rename the old file preferences for safety...
            File.Move(pathOfPrefsFile, Path.GetDirectoryName(pathOfPrefsFile) +  @"\" + Path.GetFileName(pathOfPrefsFile) + ".OLD." + Guid.NewGuid().ToString());
            // Write the new file.
            File.WriteAllLines(pathOfPrefsFile, outputLines.ToArray());
        }
        private static string GetPathOfPrefsFile()
        {
            // Get roaming folder, and get the profiles.ini
            string iniFilePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Mozilla\Firefox\profiles.ini";
            // Profiles.ini tells us what folder the preferences file is in.
            string contentsOfIni = File.ReadAllText(iniFilePath);
            int locOfPath = contentsOfIni.IndexOf("Path=Profiles");
            int endOfPath = contentsOfIni.IndexOf(".default", locOfPath);
            int startOfPath = locOfPath + "Path=Profiles".Length + 1;
            int countofCopy = ((endOfPath + ".default".Length) - startOfPath);
            string path = contentsOfIni.Substring(startOfPath, countofCopy);
            string toReturn = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Mozilla\Firefox\Profiles\" + path + @"\prefs.js";
            return toReturn;
        }
        public static bool isFireFoxOpen()
        {
            foreach (Process proc in Process.GetProcesses())
            {
                if (proc.ProcessName == "firefox")
                {
                    return true;
                }
            }
            return false;
        }
