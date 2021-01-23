        // Create a WMEncoder object.
        WMEncoder encoder = new WMEncoder();
        
        // Retrieve the source group collection.
        IWMEncSourceGroupCollection srcGrpColl = encoder.SourceGroupCollection;
        // Add a source group to the collection.
        IWMEncSourceGroup srcGrp = srcGrpColl.Add("SG_1");
        // Add a video and audio source to the source group.
        IWMEncSource srcAud = srcGrp.AddSource(WMENC_SOURCE_TYPE.WMENC_AUDIO);
        srcAud.SetInput(wavFileName, "", "");
        // Specify a file object in which to save encoded content.
        IWMEncFile file = encoder.File;
        file.LocalFileName = wmaFileName;
        // Create a profile collection object from the WMEncoder object.
        encoder.ProfileCollection.ProfileDirectory = 
            string.Format("{0}Profiles", Request.PhysicalApplicationPath);
        encoder.ProfileCollection.Refresh();
        IWMEncProfileCollection proColl = encoder.ProfileCollection;
        // Create a profile object
        IEnumerator profEnum = proColl.GetEnumerator();
        IWMEncProfile profile = null; ;
        IWMEncProfile2 newProfile = null;
        while (profEnum.MoveNext())
        {
            profile = (IWMEncProfile)profEnum.Current;
            if (profile.Name == "WavToWma")
            {
                // Load profile
                newProfile = new WMEncProfile2();
                newProfile.LoadFromIWMProfile(profile);
                // Specify this profile object as the profile to use in source group.
                srcGrp.set_Profile(newProfile);
            }
        }
        // Start the encoding process.
        // Wait until the encoding process stops before exiting the application.
        encoder.PrepareToEncode(true);
        encoder.Start();
        while (encoder.RunState != WMENC_ENCODER_STATE.WMENC_ENCODER_STOPPED)
        {
            Thread.Sleep(500);
        }
        encoder.Stop();
        encoder.Reset();
        try
        {
            #region Release com objects
            if (file != null)
                Marshal.FinalReleaseComObject(file);
            if (profile != null)
                Marshal.FinalReleaseComObject(profile);
            if (newProfile != null)
                Marshal.FinalReleaseComObject(newProfile);
            if (srcAud != null)
                Marshal.FinalReleaseComObject(srcAud);
            if (srcGrp != null)
                Marshal.FinalReleaseComObject(srcGrp);
            if (srcGrpColl != null)
                Marshal.FinalReleaseComObject(srcGrpColl);
            if (proColl != null)
                Marshal.FinalReleaseComObject(proColl);
            if (encoder != null)
                Marshal.FinalReleaseComObject(encoder);
            // GC collect is explicitly called because of a memory leak issue of WMEncoder.
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            #endregion
        }
        catch { }
    }
