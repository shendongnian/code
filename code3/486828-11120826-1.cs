    private static void GenerateIcons(Effects effect)
    {
        var dir     = new DirectoryInfo(HttpContext.Current.Server.MapPath(@"~\Icons\Original\"));
        var mappath = HttpContext.Current.Server.MapPath(@"~\Icons\");
        var ids     = GetAllEffectIds(effect.TinyUrlCode);
        
        var filesToProcess = dir
            .EnumerateFiles()
            .AsParallel()
            .Select(f => new { info = f, generated = File.Exists(mappath + @"Generated\" + ids + "-" + f.Name) })
            .ToList();
        
        Parallel.ForEach(filesToProcess.Where(f => !f.generated), file =>
        {
            new ApplyEffects(effect, file.info.Name, mappath).SaveIcon();
        });
        
        //Zip icons!
        ZipFiles(filesToProcess.Select(f => f.info), effect.TinyUrlCode, ids, effect.General.Prefix);
    }
