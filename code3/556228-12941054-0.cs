        static void Main(string[] args)
        {
            const string rtmpDump = "rtmpdump.exe";
            const string rtmpDumpArguments = "-v -r rtmp://{stream} -o 1.flv -B 1";
            sRunExternalExe(rtmpDump, rtmpDumpArguments);
            const string ffmpeg = "ffmpeg.exe";
            const string ffmpegArguments = "-i 1.flv -ss 00:00:01 -an -r 1 -vframes 1 -s 400x300 -y 1.jpg";
            RunExternalExe(ffmpeg, ffmpegArguments);
            var theFile = new FileInfo("1.flv");
            if (theFile.Exists)
            {
                File.Delete("1.flv");
            }
        }
        public static string RunExternalExe(string filename, string arguments = null)
        {
            var process = new Process();
            process.StartInfo.FileName = filename;
            if (!string.IsNullOrEmpty(arguments))
            {
                process.StartInfo.Arguments = arguments;
            }
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.RedirectStandardOutput = true;
            var stdOutput = new StringBuilder();
            process.OutputDataReceived += (sender, args) => stdOutput.Append(args.Data);
            string stdError = null;
            try
            {
                process.Start();
                process.BeginOutputReadLine();
                stdError = process.StandardError.ReadToEnd();
                process.WaitForExit();
            }
            catch (Exception e)
            {
                throw new Exception("OS error while executing " + Format(filename, arguments) + ": " + e.Message, e);
            }
            if (process.ExitCode == 0 || process.ExitCode == 2)
            {
                return stdOutput.ToString();
            }
            else
            {
                var message = new StringBuilder();
                if (!string.IsNullOrEmpty(stdError))
                {
                    message.AppendLine(stdError);
                }
                if (stdOutput.Length != 0)
                {
                    message.AppendLine("Std output:");
                    message.AppendLine(stdOutput.ToString());
                }
                throw new Exception(Format(filename, arguments) + " finished with exit code = " + process.ExitCode + ": " + message);
            }
        }
        private static string Format(string filename, string arguments)
        {
            return "'" + filename +
                ((string.IsNullOrEmpty(arguments)) ? string.Empty : " " + arguments) +
                "'";
        }
