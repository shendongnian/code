    Process p = new Process();
                    p.StartInfo.UseShellExecute = true;
                    p.StartInfo.WorkingDirectory = Application.StartupPath;
                    p.StartInfo.FileName = General.DnsBatPath;
                    p.StartInfo.Arguments = string.Format("{0} {1}", General.DnsServerName, txtSiteAddress.Text);
                    p.Start();
                    p.WaitForExit();
