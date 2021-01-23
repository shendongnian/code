    private Dictionary<int?, ScanClass> GetAllLocalScanFiles()
    {
        using (DZine_IStylingEntities ctxLocal = new DZine_IStylingEntities())
        {
            return ctxLocal.tblScan
                     .Select(s => new { s.MEMBERID, s.scanFileAvatar, s.hair })
                     .AsParallel()
                     .ToDictionary(s => s.MEMBERID, s => new ScanClass {
                                       hair = s.hair,
                                       scanFileAvatar = s.scanFileAvatar
                                   });
        }
    }
