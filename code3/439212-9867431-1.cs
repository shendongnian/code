    public class HomeController : AsyncController
    {
        public void IndexAsync()
        {
            var process = new Process();
            process.StartInfo.FileName = "c:\\Program Files\\PostgreSql\\9.1\\bin\\pg_dump.exe";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.EnableRaisingEvents = true;
            AsyncManager.OutstandingOperations.Increment();
            process.Exited += (sender, e) =>
            {
                var proc = ((Process)sender);
                string result = null;
                if (proc.ExitCode == 0)
                {
                    result = proc.StandardOutput.ReadToEnd();
                }
                else
                {
                    result = proc.StandardError.ReadToEnd();
                }
                AsyncManager.Parameters["result"] = result;
                AsyncManager.OutstandingOperations.Decrement();
                Writelog("Backup has completed");
            };
            process.Start();
        }
        public ActionResult IndexCompleted(string result)
        {
            return File(Encoding.UTF8.GetBytes(result), "text/plain");
        }
    }
