    /// <summary>
    /// Extract a thumbnail from the middle (by duration) of a video file
    /// </summary>
    /// <param name="inputFileName">Path to the video file on the local filesystem</param>
    /// <param name="duration">Duration of the video</param>
    /// <returns></returns>
    public Image ExtractThumbnail(string inputFileName)
    {
        if (string.IsNullOrEmpty(inputFileName))
        {
            throw new ArgumentNullException("inputFileName", "Input file is null");
        }
            
        TimeSpan duration = GetVideoDuration(inputFileName);
        const string framegrabTemplate = @"-i ""{0}"" -frames:v 1 -ss {2:##0.0##} -f image2 {1}";
        string framegrabArgs = string.Format(framegrabTemplate, inputFileName, OutputFileName, duration.TotalSeconds / 2);
        WindowsProcessResult result = null;
            
        try
        {
            result = WindowsProcessUtil.RunProcess(ExePath, framegrabArgs);
        }
        catch (Exception ex)
        {
            log.Error("Framegrab process failed with exception {0}.", ex);
            return null;
        }
        if (result.ExitCode != 0)
        {
            log.Error("Framegrab process failed with exitCode {0}. Process output:\r\n{1}\r\nProcess Error: {2}", result.ExitCode, result.StandardOutput, result.StandardError);
            return null;
        }
        var img = Image.FromFile(OutputFileName);
        //Certain video sources (primarily iOS v5 and below) will give you videos rotated to one side with embedded metadata telling you what that rotation is
        //If you need to deal with that, you can set rotationAngle from that metadata, but that's a whole other issue
        //Leaving it here for now as an FYI
        //int rotationAngle = 0;
        //if (rotationAngle != 0)
        //{
        //    if (rotationAngle == 90)
        //    {
        //        img.RotateFlip(RotateFlipType.Rotate90FlipNone);
        //    }
        //    else if (rotationAngle == 180)
        //    {
        //        img.RotateFlip(RotateFlipType.Rotate180FlipNone);
        //    }
        //    else if (rotationAngle == 270)
        //    {
        //        img.RotateFlip(RotateFlipType.Rotate270FlipNone);
        //    }
        //}
        return img;
    }
    private static readonly Regex durationRegex = new Regex(@"Duration\: (?<duration>[\d\:\.]+)", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture);
    private TimeSpan GetVideoDuration(string inputFileName)
    {
        Process getDurationProcess = null;
        try
        {
            const string fileInfoTemplate = @"-i ""{0}""";
            ProcessStartInfo psi = new ProcessStartInfo(ExePath, string.Format(fileInfoTemplate, inputFileName));
            psi.UseShellExecute = false;
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardError = true;
            psi.CreateNoWindow = true;
            //psi.WorkingDirectory = Path.GetDirectoryName(ExePath);
            //psi.EnvironmentVariables["Path"] = psi.EnvironmentVariables["Path"] + ";" + Path.GetDirectoryName(ExePath);
            getDurationProcess = new Process();
            getDurationProcess.StartInfo = psi;
            getDurationProcess.EnableRaisingEvents = true;
                
            StringBuilder processOutput = new StringBuilder();
            StringBuilder processError = new StringBuilder();
            getDurationProcess.OutputDataReceived += (o, args) =>
            {
                processOutput.AppendLine(args.Data);
            };
            getDurationProcess.ErrorDataReceived += (o, args) =>
            {
                processError.AppendLine(args.Data);
            };
            getDurationProcess.Start();
            getDurationProcess.BeginOutputReadLine();
            getDurationProcess.BeginErrorReadLine();
            getDurationProcess.WaitForExit();
            //Don't do this - ffmpeg errors out because we didn't give it an output file
            //if (getDurationProcess.ExitCode != 0)
            //{
            //    log.Error("Get video duration process failed with exitCode {0}. Process output:\r\n{1}\r\nProcess Error: {2}", getDurationProcess.ExitCode, processOutput, processError);
            //}
            //Now we need to parse output
            #region Sample output
            /*
                ffmpeg version git-N-29946-g27614b1, Copyright (c) 2000-2011 the FFmpeg developers
                built on May 15 2011 15:07:09 with gcc 4.5.3
                configuration: --enable-gpl --enable-version3 --enable-memalign-hack --enable-
            runtime-cpudetect --enable-avisynth --enable-bzlib --enable-frei0r --enable-libo
            pencore-amrnb --enable-libopencore-amrwb --enable-libfreetype --enable-libgsm --
            enable-libmp3lame --enable-libopenjpeg --enable-librtmp --enable-libschroedinger
                --enable-libspeex --enable-libtheora --enable-libvorbis --enable-libvpx --enabl
            e-libx264 --enable-libxavs --enable-libxvid --enable-zlib --pkg-config=pkg-confi
            g
                libavutil    51.  2. 1 / 51.  2. 1
                libavcodec   53.  5. 0 / 53.  5. 0
                libavformat  53.  0. 3 / 53.  0. 3
                libavdevice  53.  0. 0 / 53.  0. 0
                libavfilter   2.  5. 0 /  2.  5. 0
                libswscale    0. 14. 0 /  0. 14. 0
                libpostproc  51.  2. 0 / 51.  2. 0
            Seems stream 0 codec frame rate differs from container frame rate: 180000.00 (18
            0000/1) -> 30.00 (30/1)
            Input #0, mov,mp4,m4a,3gp,3g2,mj2, from '..\fromQuicktime.mp4':
                Metadata:
                major_brand     : mp42
                minor_version   : 0
                compatible_brands: mp42isomavc1
                creation_time   : 2011-04-22 16:36:45
                encoder         : HandBrake 0.9.5 2011010300
                Duration: 00:00:22.13, start: 0.000000, bitrate: 712 kb/s
                Stream #0.0(und): Video: h264 (High), yuv420p, 480x272, 578 kb/s, 30 fps, 30
                tbr, 90k tbn, 180k tbc
                Metadata:
                    creation_time   : 2011-04-22 16:36:45
                Stream #0.1(und): Audio: aac, 44100 Hz, mono, s16, 127 kb/s
                Metadata:
                    creation_time   : 2011-04-22 16:36:45
            At least one output file must be specified
                * */
            #endregion
            processOutput.Append(processError.ToString());
            Match m = durationRegex.Match(processOutput.ToString());
            Group durationGroup = m.Groups["duration"];
                
            TimeSpan duration;
            if (!TimeSpan.TryParse(durationGroup.Value, out duration))
            {
                log.Error("Failed to parse duration from FFMpeg output:\r\n{0}", processOutput);
                return TimeSpan.Zero;
            }
            else
            {
                return duration;
            }
        }
        finally
        {
            if (getDurationProcess != null)
            {
                getDurationProcess.Dispose();
                getDurationProcess = null;
            }
        }
    }
