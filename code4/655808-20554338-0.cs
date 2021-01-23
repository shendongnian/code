        public static string DecryptFile(string encryptedFilePath)
        {
            FileInfo info = new FileInfo(encryptedFilePath);
            string decryptedFileName = info.FullName.Substring(0, info.FullName.LastIndexOf('.')) + "Dec.TXT";
            string encryptedFileName = info.FullName;
            string password = System.Configuration.ConfigurationManager.AppSettings["passphrase"].ToString();
            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo("cmd.exe");
            psi.CreateNoWindow = true;
            psi.UseShellExecute = false;
            psi.RedirectStandardInput = true;
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardError = true;
            psi.WorkingDirectory = @System.Configuration.ConfigurationManager.AppSettings["WorkingDirectory"].ToString();
            System.Diagnostics.Process process = System.Diagnostics.Process.Start(psi);
            string sCommandLine = @"echo " + password + "|gpg.exe --passphrase-fd 0 --batch --verbose --yes --output " + decryptedFileName + @" --decrypt " + encryptedFileName;
            process.StandardInput.WriteLine(sCommandLine);
            process.StandardInput.Flush();
            process.StandardInput.Close();
            process.WaitForExit();
            //string result = process.StandardOutput.ReadToEnd();
            //string error = process.StandardError.ReadToEnd();
            process.Close();
            return decryptedFileName;
        }
