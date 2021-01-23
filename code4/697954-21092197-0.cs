    ...<code to generate "filename" goes here>...
    // BUG: For some reason, even though the cache file has definitely been created at this stage, the file dependency manager
    // seems to require a bit of time to "register" that the file exists before we add it to the list of dependencies.
    // If we don't tell the thread to sleep, we will get an error when it generates the eTag (no idea why this happens - can't find anything on the web).
    // If the cache file already existed when this request began, then there is no error.
    Thread.Sleep(5);
    context.Response.AddFileDependency(filename);                
    context.Response.Cache.SetLastModifiedFromFileDependencies();
    context.Response.Cache.SetETagFromFileDependencies();
    context.Response.Cache.SetCacheability(HttpCacheability.Public);
    context.Response.Cache.SetMaxAge(new TimeSpan(999,0,0,0));
    context.Response.Cache.SetSlidingExpiration(true);
    context.Response.Cache.SetValidUntilExpires(true);                
    context.Response.Cache.VaryByParams["*"] = true;
    byte[] buffer = File.ReadAllBytes(filename);
    context.Response.ContentType = MimeMapping.GetMimeMapping(mi.Mi_filename);
    context.Response.StatusCode = 200;
    context.Response.BinaryWrite(buffer);
