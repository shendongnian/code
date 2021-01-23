    public void FindRegionDetailsFromRegionCodes(IUserQuery userQuery,
                                                 IRegionMapper regionMapper,
                                                 IUserDisplay userResult) {
        var regions = regionMapper.Get(userQuery.RegionCodes);
        userResult.ShowResult(regions);
    }
