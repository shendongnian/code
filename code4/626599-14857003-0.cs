        static void Main(string[] args)
        {
            if (args.Length < 1)
                return;
            string vlc = @"C:\Program Files\VideoLAN\VLC\vlc.exe";
            string videoFile = args[0];
            string pathAffected = @"C:\Users\User1\Downloads";
            string destinationPath = @"C:\temp\";
            Process vlcProcess = new Process();
            vlcProcess.StartInfo.FileName = vlc;
            vlcProcess.StartInfo.Arguments = "\"" + videoFile + "\"";
            vlcProcess.StartInfo.Arguments += " --play-and-exit";
            vlcProcess.Start();
            vlcProcess.WaitForExit();
            if (videoFile.IndexOf(pathAffected,
                StringComparison.InvariantCultureIgnoreCase) >= 0)
            {
                System.IO.File.Move(videoFile,
                    System.IO.Path.Combine(destinationPath,
                    System.IO.Path.GetFileName(videoFile)));
            }
        }
