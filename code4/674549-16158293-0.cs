    List<Keyframe> region = new List<Keyframe>();
    
    long highestTicks = 0;
    long durationTicks = 0; //Stores the whole duration of this new region
    
    long baseTicks = clip.Keyframes[beginFrame].Time.Ticks;
    //beginFrame and endFrame are 300 and 800
    for (int i = beginFrame; i <= endFrame; i += 1)
    {
        //Clip is the full list of keyframes
        Keyframe k = clip.Keyframes[i];
        k.Time = TimeSpan.FromTicks(k.Time.Ticks - baseTicks);
        highestTicks = Math.Max(highestTicks, k.Time.Ticks);
         region.Add(k);
    }
    durationTicks = highestTicks;
