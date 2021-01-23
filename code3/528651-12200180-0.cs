    public DataSet ReturnPhysicianSpecialtyCodes() {
        HttpContext context = HttpContext.Current;
        string cacheKey = "PhysCodes";
        DataSet cacheItem = (DataSet)context.Cache.Get(cacheKey);
        if(cacheItem == null) {
            string sqlCommand =
                "SELECT DISTINCT SPECIALTY_CODE, SPECIALTY " +
                "FROM PHARM.PHYSICIAN_SPECIALTY " +
                "ORDER BY SPECIALTY";
            cacheItem = OracleHelper.ExecuteDataset(
                this.Connection,
                CommandType.Text,
                sqlCommand);
            context.Cache.Add(
                cacheKey,
                cacheItem,
                null,
                Cache.NoAbsoluteExpiration,
                Cache.NoSlidingExpiration,
                CacheItemPriority.Normal,
                null);
        }
        return (DataSet)cacheItem;
    }
