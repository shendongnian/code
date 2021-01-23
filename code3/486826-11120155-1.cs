    Parallel.ForEach(ff, item =>
    {
        if (!File.Exists(mappath + @"Generated\" + ids + "-" + item.Name))
        {
            lock(paths) 
            {
                paths.Add(mappath + @"Generated\" + ids + "-" + item.Name);
            }
            ApplyEffects f = new ApplyEffects(effect, item.Name, mappath);
            f.SaveIcon();
        }
    });
