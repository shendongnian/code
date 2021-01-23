    public static int RunMySql(string server, int port, string user, string password, string database, string filename)
    {
        var process = Process.Start(
            new ProcessStartInfo
            {
                FileName = @"C:\Program Files (x86)\MySQL\MySQL Server 5.0\bin\mysql.exe",
                Arguments =
                    String.Format(
                        "-C -B --host={0} -P {1} --user={2} --password={3} --database={4} -e \"\\. {5}\"",
                        server, port, user, password, database, filename),
                ErrorDialog = false,
                CreateNoWindow = true,
                UseShellExecute = false,
                RedirectStandardError = true,
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                WorkingDirectory = Environment.CurrentDirectory,
            }
            );
        process.OutputDataReceived += (o, e) => Console.Out.WriteLine(e.Data);
        process.ErrorDataReceived += (o, e) => Console.Error.WriteLine(e.Data);
        process.Start();
        process.BeginErrorReadLine();
        process.BeginOutputReadLine();
        process.StandardInput.Close();
        process.WaitForExit();
        return process.ExitCode;
    }
