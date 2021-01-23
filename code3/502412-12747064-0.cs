    System.Diagnostics.ProcessStartInfo PSI =
    new System.Diagnostics.ProcessStartInfo("cmd", "/c " + "Repadmin.exe /showbackup");
    
    PSI.RedirectStandardOutput = true;
    PSI.UseShellExecute = false;
    
    PSI.CreateNoWindow = true;
    System.Diagnostics.Process proc = new System.Diagnostics.Process();
    proc.StartInfo = PSI;
    proc.Start();
    string result = proc.StandardOutput.ReadToEnd();
    Console.WriteLine(result);
          }
          catch (Exception e)
          {
          Messagebox.Show(e.InnerException);
          }
    }
