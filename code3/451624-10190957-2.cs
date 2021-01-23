            public VideoFile GetVideoInfo(string inputPath)
            {
                VideoFile vf = null;
                try
                {
                    vf = new VideoFile(inputPath);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                GetVideoInfo(vf);
                return vf;
            }
            public void GetVideoInfo(VideoFile input)
            {
                //set up the parameters for video info
                string Params = string.Format("-i {0}", input.Path);
                string output = RunProcess(Params);
                input.RawInfo = output;
     
                //get duration
                Regex re = new Regex("[D|d]uration:.((\\d|:|\\.)*)");
                Match m = re.Match(input.RawInfo);
    
                if (m.Success)
                {
                    string duration = m.Groups[1].Value;
                    string[] timepieces = duration.Split(new char[] { ':', '.' });
                    if (timepieces.Length == 4)
                    {
                        input.Duration = new TimeSpan(0, Convert.ToInt16(timepieces[0]), Convert.ToInt16(timepieces[1]), Convert.ToInt16(timepieces[2]), Convert.ToInt16(timepieces[3]));
                    }
                }
           }
