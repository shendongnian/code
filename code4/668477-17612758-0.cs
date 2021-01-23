        /// <summary>
        /// Package files. (Build Rar File)
        /// </summary>
        /// <param name="rarPackagePath">Rar File Path</param>
        /// <param name="accFiles">List Of Files To be Package</param>
        public static string RarFiles(string rarPackagePath,
            Dictionary<int, string> accFiles)
        {
            string error = "";
            try
            {
                string[] files = new string[accFiles.Count];
                int i = 0;
                foreach (var fList_item in accFiles)
                {
                    files[i] = "\"" + fList_item.Value;
                    i++;
                }
                string fileList = string.Join("\" ", files);
                fileList += "\"";
                System.Diagnostics.ProcessStartInfo sdp = new System.Diagnostics.ProcessStartInfo();
                string cmdArgs = string.Format("A {0} {1} -ep1 -r",
                    String.Format("\"{0}\"", rarPackagePath),
                    fileList);
                sdp.ErrorDialog = false;
                sdp.UseShellExecute = true;
                sdp.Arguments = cmdArgs;
                sdp.FileName = winrarPath;//Winrar.exe path
                sdp.CreateNoWindow = false;
                sdp.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                System.Diagnostics.Process process = System.Diagnostics.Process.Start(sdp);
                process.WaitForExit();
                error = "OK";
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            return error;
        }
