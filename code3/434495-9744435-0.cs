    string outputFile = "FadeBetweenImages.wmv";
    using (ITimeline timeline = new DefaultTimeline())
    {
        IGroup group = timeline.AddVideoGroup(32, 160, 100);
        ITrack videoTrack = group.AddTrack();
        IClip clip1 = videoTrack.AddImage("image1.jpg", 0, 2); // play first image for a little while
        IClip clip2 = videoTrack.AddImage("image2.jpg", 0, 2); // and the next
        IClip clip3 = videoTrack.AddImage("image3.jpg", 0, 2); // and finally the last
        IClip clip4 = videoTrack.AddImage("image4.jpg", 0, 2); // and finally the last
    }
    
      double halfDuration = 0.5;
    
      // fade out and back in
      group.AddTransition(clip2.Offset - halfDuration, halfDuration, StandardTransitions.CreateFade(), true);
      group.AddTransition(clip2.Offset, halfDuration, StandardTransitions.CreateFade(), false);
    
      // again
      group.AddTransition(clip3.Offset - halfDuration, halfDuration, StandardTransitions.CreateFade(), true);
      group.AddTransition(clip3.Offset, halfDuration, StandardTransitions.CreateFade(), false);
    
      // and again
      group.AddTransition(clip4.Offset - halfDuration, halfDuration, StandardTransitions.CreateFade(), true);
      group.AddTransition(clip4.Offset, halfDuration, StandardTransitions.CreateFade(), false);
    
      // add some audio
      ITrack audioTrack = timeline.AddAudioGroup().AddTrack();
    
      IClip audio =
         audioTrack.AddAudio("testinput.wav", 0, videoTrack.Duration);
    
      // create an audio envelope effect, this will:
      // fade the audio from 0% to 100% in 1 second.
      // play at full volume until 1 second before the end of the track
      // fade back out to 0% volume
      audioTrack.AddEffect(0, audio.Duration,
                     StandardEffects.CreateAudioEnvelope(1.0, 1.0, 1.0, audio.Duration));
    
      // render our slideshow out to a windows media file
      using (
         IRenderer renderer =
            new WindowsMediaRenderer(timeline, outputFile, WindowsMediaProfiles.HighQualityVideo))
      {
         renderer.Render();
      }
    }
