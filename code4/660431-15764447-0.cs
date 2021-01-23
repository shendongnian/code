       string applicationPath = ...;
       private ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo(applicationPath);
       //set working directiory
       Directory.SetCurrentDirectory(Path.GetDirectoryName(applicationPath));
       psi.WorkingDirectory = Path.GetDirectoryName(applicationPath);
       //psi.CreateNoWindow = false;
       psi.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
       //psi.UseShellExecute = false;
       prcs = System.Diagnostics.Process.Start(psi);
