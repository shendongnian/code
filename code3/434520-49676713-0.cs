    public bool CreateVideo(List<Bitmap> bitmaps, string outputFile, double fps)
            {
                int width = 640;
                int height = 480;
                if (bitmaps == null || bitmaps.Count == 0) return false;
                try
                {
                    using (ITimeline timeline = new DefaultTimeline(fps))
                    {
                        IGroup group = timeline.AddVideoGroup(32, width, height);
                        ITrack videoTrack = group.AddTrack();
                        
                        int i = 0;
                        double miniDuration = 1.0 / fps;
                        foreach (var bmp in bitmaps)
                        {
                            IClip clip = videoTrack.AddImage(bmp, 0, i * miniDuration, (i + 1) * miniDuration);
                            System.Diagnostics.Debug.WriteLine(++i);
    
                        }
                        timeline.AddAudioGroup();
                        IRenderer renderer = new WindowsMediaRenderer(timeline, outputFile, WindowsMediaProfiles.HighQualityVideo);
                        renderer.Render();
                    }
                }
                catch { return false; }
                return true;
            }
