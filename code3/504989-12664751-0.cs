            Process proc = new Process();
            proc.StartInfo.FileName = @"C:\Program Files\Adobe\Acrobat 7.0\Reader\AcroRd32.exe";
            proc.StartInfo.Arguments = @"/p /h C:\Documents and Settings\brendal\Desktop\Test.pdf";
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.CreateNoWindow = true;
            proc.Start();
            for (int i = 0; i < 5; i++)
            {
                if (!proc.HasExited)
                {
                    proc.Refresh();
                    Thread.Sleep(2000);
                }
                else
                    break;
            }
            if (!proc.HasExited)
            {
                proc.CloseMainWindow();
            }
