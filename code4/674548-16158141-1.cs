    var tickOffset = clip.Keyframes[beginFrame].Time.Ticks;
    // this is your 'region' variable
    var adjustedFrames = clip.Keyframes
        .Skip(beginFrame)
        .Take(endFrame - beginFrame)
        .Select(kf => new Keyframe { 
            Time = TimeSpan.FromTicks(kf.Time.Ticks - tickOffset),
            OtherProperty = kf.OtherProperty            
        })
        .ToList();
    var durationTicks = adjustedFrames.Max(k => k.Time.Ticks);
