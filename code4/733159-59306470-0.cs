    IntPtr wow64Value = IntPtr.Zero;
            try
            {
                Wow64Interop.DisableWow64FSRedirection(ref wow64Value);
                ProcessStartInfo psi1 =
            new ProcessStartInfo("cmd.exe");
                psi1.UseShellExecute = false;
                psi1.RedirectStandardOutput = true;
                psi1.RedirectStandardInput = true;
                psi1.CreateNoWindow = true;
                psi1.Verb = "runas";
                Process ps1 = Process.Start(psi1);
                ps1.EnableRaisingEvents = true;
                StreamWriter inputWrite1 = ps1.StandardInput;
                // uses extra cheap logging facility
                inputWrite1.WriteLine("chcp 437");
                inputWrite1.WriteLine("rstrui.exe");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unabled to disable/enable WOW64 File System Redirection");
                Console.WriteLine(ex.Message);
            }
            finally
            {
                // 3. Let the Wow64FSRedirection with its initially state
                Wow64Interop.Wow64RevertWow64FsRedirection(wow64Value);
            }
