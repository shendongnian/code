    public AssetValuationHeader GetValuationHeaderById(int id)
    {
        return this.AssetValuationHeaders
            .Include("AssetHoldings")
            .Include("AssetHoldings").Select(sa => sa.SwapAssetHoldingNotionals)
            .Where(vh => vh.Id == id)
            .FirstOrDefault();
    }
