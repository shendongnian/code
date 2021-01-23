    var tickOffset = clip.Keyframes[beginFrame].Time.Ticks;
    // this is your 'region' variable
    var adjustedFrames = clip.Keyframes
        .Skip(beginFrame)
        .Take(endFrame - beginFrame)
        .Select(c => new Keyframe { Time = TimeSpan.FromTicks(c.Time.Ticks - tickOffset) })
        .ToList();
    var durationTicks = adjustedFrames.Max(k => k.Time.Ticks);
