    public static void UnrarFiles(string rarPackagePath, string dir)
        {
            System.Diagnostics.ProcessStartInfo sdp = new System.Diagnostics.ProcessStartInfo();
            string cmdArgs = string.Format("X {0} * {1}",
                String.Format("\"{0}\"", rarPackagePath),
                String.Format("\"{0}\"", dir));
            sdp.Arguments = cmdArgs;
            sdp.ErrorDialog = true;
            sdp.UseShellExecute = true;
            sdp.CreateNoWindow = false;
            sdp.FileName = rarPath;
            sdp.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            System.Diagnostics.Process process = System.Diagnostics.Process.Start(sdp);
            process.WaitForExit();
        }
