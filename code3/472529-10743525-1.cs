    internal static string ElevatedExecute(NameValueCollection parameters)
        {
            string tempFile = Path.GetTempFileName();
            File.WriteAllText(tempFile, ConstructQueryString(parameters));
            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.UseShellExecute = true;
                startInfo.WorkingDirectory = Environment.CurrentDirectory;
                Uri uri = new Uri(Assembly.GetExecutingAssembly().GetName().CodeBase);
                startInfo.FileName = uri.LocalPath;
                startInfo.Arguments = "\"" + tempFile + "\"";
                startInfo.Verb = "runas";
                Process p = Process.Start(startInfo);
                p.WaitForExit();
                return File.ReadAllText(tempFile);
            }
            catch (Win32Exception exception)
            {
                return exception.Message;
            }
            finally
            {
                File.Delete(tempFile);
            }
        }
